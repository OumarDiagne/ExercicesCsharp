namespace Facturation
{
   public class Prestation
   {


      #region Constantes et variables
      #endregion

      #region Propriétés Publiques
      public int Identifiant { get; set; }
      public string Intitule { get; set; } = string.Empty;
      public decimal PrixHT { get; set; }
      public DateTime Datedebut { get; set; }
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
}
