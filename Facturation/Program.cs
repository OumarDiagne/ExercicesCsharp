using System.Text;

namespace Facturation
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Console.OutputEncoding = Encoding.Unicode;
         TesterClientsPresta();
      }

      static void TesterClientsPresta()
      {
         //-------------------------------------------------------------
         // Prestation classique à un particulier

         // Crée un client particulier
         Particulier p = new(Civilite.Mr, "Dupont", "Eric")
         { Adresse = "29 rue de la liberté - 88000 Epinal" };

         // Crée une prestation classique pour ce client
         DateTime dt0 = new DateTime(2024, 5, 15);
         Prestation presta = new(p.IdentifiantInterne, dt0, "Déclaration de revenus 2023", 300m);

         // Affiche l'ensemble
         Console.WriteLine($"""
      Client N°{p.IdentifiantInterne} : {p.Civilite} {p.Prenom} {p.Nom}
      Prestation : {presta.Intitule}
      Prix : {presta.PrixHT:C2}
      Date : {presta.Datedebut:d}
      """);
         Facture facture = new(p, presta, dt0);
         Console.WriteLine(facture.Editer());
         //-------------------------------------------------------------
         // Prestation long terme à une entreprise

         // Crée un client de type entreprise
         Entreprise e = new("Microsoft France", 32773318400516)
         { Adresse = "39 quai du Président Roosevelt, 92130 Issy-les-Moulineaux" };

         // Crée une prestation long terme pour ce client
         DateTime dt = new DateTime(2024, 1, 1);
         PrestationComplexe plt = new(e.IdentifiantInterne, dt, "Compta trimestrielle", 2000m);

         // Crée les étapes mensuelles
         for (int i = 1; i <= 4; i++)
         {
            DateTime dateFinEtape = dt.AddMonths(3 * i).AddDays(-1);
            plt.AjouterEtape(dateFinEtape, i / 4f, $"Compta du trimestre {i}");
            FactureComplexe fs = new(e, plt, dateFinEtape.AddDays(1));
            Console.WriteLine(fs.Editer());
         }

         // Affiche l'ensemble
         Console.WriteLine($"""

      Client N°{e.IdentifiantInterne} : {e.RaisonSociale}, SIRET : {e.NumeroSiret}
      Prestation : {plt.Intitule} ({plt.Etapes.Count} étapes)
      Prix : {plt.PrixHT:C2}
      Date début : {plt.Datedebut:d}
      Etapes :
      """);

         foreach (Etape etape in plt.Etapes)
         {
            Console.WriteLine($"- {etape.Libelle} du {etape.DateDebut:d} au {etape.DateFin:d} ({etape.Avancement:##%})");
         }



         Console.WriteLine("***************************************************************************************************\n\n");

         FactureComplexe factureComplexe = new(e, plt, plt.Etapes.Last().DateDebut);



      }
   }


}