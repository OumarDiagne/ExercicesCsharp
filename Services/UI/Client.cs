namespace Services.UI
{
   public abstract class Client : IClient
   {
      private static int _compteurInstances;
      #region Propriétés
      public int IdentifiantInterne { get { return _compteurInstances; } }
      public string Adresse { get; set; } = string.Empty;

      public virtual string NomComplet { get; protected set; } = string.Empty;

      public int Id => _compteurInstances;

      string IClient.NomComplet { get; } = string.Empty;
      #endregion

      #region Constructeur
      public Client()
      {
         _compteurInstances++;

      }
      #endregion


      #region methodes
      public override string ToString()
      {
         return $"""
         Référence : {IdentifiantInterne}
         {NomComplet}
         Adresse : {Adresse}
         """;
      }
      #endregion
   }
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
