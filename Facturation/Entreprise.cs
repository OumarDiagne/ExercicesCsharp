namespace Facturation
{
   public class Entreprise : Client
   {
      #region Propriétés
      public long NumeroSiret { get; set; }
      public string RaisonSociale { get; set; }
      public override string NomComplet => $"Société {RaisonSociale}";
      #endregion

      #region Constructeur
      public Entreprise(string raisonSociale, long numeroSiret)
      {
         NumeroSiret = numeroSiret;
         RaisonSociale = raisonSociale;

      }
      #endregion

      #region methodes
      public override string ToString()
      {
         return $"""
         {base.ToString()}
         SIRET : {NumeroSiret:### ### ### #####}
         """;
      }
      #endregion
   }


}
