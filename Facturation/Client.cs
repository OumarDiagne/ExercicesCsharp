namespace Facturation
{
   public abstract class Client
   {
      private static int _compteurInstances;
      #region Propriétés
      public int IdentifiantInterne { get { return _compteurInstances; } }
      public string Adresse { get; set; } = string.Empty;

      public virtual string NomComplet { get; protected set; } = string.Empty;
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
}
