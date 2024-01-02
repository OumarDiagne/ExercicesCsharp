namespace Facturation
{
   public class PrestationComplexe : Prestation
   {
      #region Constantes et variables
      #endregion

      #region Propriétés Publiques
      public List<Etape> Etapes { get; set; }
      #endregion

      #region Constructeurs
      public PrestationComplexe(int identifiant, DateTime dateDebut, string intitule, decimal prixHT) : base(identifiant, dateDebut, intitule, prixHT)
      {
         Etapes = new List<Etape>();
      }
      #endregion

      #region Méthodes d'instances
      public void AjouterEtape(DateTime dateFin, float avancement, string libellé = "étape intermédiaire")
      {
         DateTime dateDébut = Datedebut;
         if (Etapes.Any())
            dateDébut = Etapes.Last().DateFin.AddDays(1);

         Etapes.Add(new Etape(dateDébut, dateFin, avancement, libellé));
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
}

