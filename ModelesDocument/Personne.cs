namespace ModelesDocument
{
   internal class Personne
   {

      #region Propriétés
      public string Nom { get; set; }
      public string Prenom { get; set; }
      #endregion


      #region Constructeur
      public Personne(string nom, string prenom)
      {
         Nom = nom;
         Prenom = prenom;
      }
      #endregion
   }
}
