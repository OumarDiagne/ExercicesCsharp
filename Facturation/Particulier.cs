namespace Facturation
{
   public enum Civilite { Mr = 0, Melle = 1, Mme = 2 }

   public class Particulier : Client
   {

      #region Propriétés
      public Civilite Civilite { get; set; }
      public string Nom { get; set; }
      public string Prenom { get; set; }
      public override string NomComplet => $"{Civilite} {Nom} {Prenom}";
      #endregion

      #region Constructeurs
      public Particulier(Civilite civilite, string nom, string prenom)
      {
         Civilite = civilite;
         Nom = nom;
         Prenom = prenom;


      }

      #endregion

      #region methodes
      public override string ToString()
      {
         return $"""
            Client :
            Référence : {IdentifiantInterne}
            {Civilite} {Nom} {Prenom}
            Adresse : {Adresse}
            """;
      }
      #endregion
   }
}
