using System.Collections.ObjectModel;

namespace Services.UI
{
   public class Prestations
   {
      public class Prestation : IPrestation
      {


         #region Constantes et variables
         #endregion

         #region Propriétés Publiques
         public int Identifiant { get; set; }
         public string Intitule { get; set; } = string.Empty;
         public decimal PrixHT { get; set; }
         public DateTime Datedebut { get; set; }
         public long IdClient { get; set; }

         public DateTime DateDebut { get; }
         #endregion

         #region Constructeurs
         public Prestation(int identifiant, DateTime dateDebut, string intitule, decimal prixHT)
         {
            Identifiant = identifiant;
            Intitule = intitule;
            PrixHT = prixHT;
            Datedebut = dateDebut;
         }
         #endregion

         #region Méthodes d'instances
         public override string ToString()
         {
            return $"Prestation du {Datedebut:d} : {Intitule}";
         }
         #endregion

         #region Methodes Privées
         #endregion

         #region Methodes Statiques
         #endregion
      }

      public class PrestationComplexe : Prestation, IPrestationLongTerme
      {
         #region Constantes et variables
         #endregion

         #region Propriétés Publiques
         private List<Etape> _étapes;
         public ReadOnlyCollection<Etape> Etapes => _étapes.AsReadOnly();
         #endregion

         #region Constructeurs
         public PrestationComplexe(int idClient, DateTime dateDébut, string intitulé, decimal prixHT) :
         base(idClient, dateDébut, intitulé, prixHT)
         {
            _étapes = new();
         }
         #endregion

         #region Méthodes d'instances
         public void AjouterEtape(DateTime dateFin, float avancement, string libellé = "étape intermédiaire")
         {
            DateTime dateDébut = Datedebut;
            if (Etapes.Any())
               dateDébut = Etapes.Last().DateFin.AddDays(1);

            _étapes.Add(new Etape(dateDébut, dateFin, avancement, libellé));
         }

         public override string ToString()
         {
            return Etapes.Last().ToString();
         }



         #endregion

         #region Methodes Privées
         #endregion

         #region Methodes Statiques
         #endregion

      }

      public class Etape
      {

         #region Propriétés publiques
         public string Libelle { get; set; } = string.Empty;
         public float Avancement { get; set; }
         public DateTime DateDebut { get; set; }
         public DateTime DateFin { get; set; }
         #endregion

         #region Constructeur
         public Etape(DateTime dateDébut, DateTime dateFin, float avancement, string libellé)
         {
            DateDebut = dateDébut;
            DateFin = dateFin;
            Avancement = avancement;
            Libelle = libellé;
         }

         public override string ToString()
         {
            return $"""
      Prestation : {Libelle}
      Période du {DateDebut:d} au {DateFin:d}
      Avancement : {Avancement:#%}
      """;
         }
         #endregion


      }
   }
}
