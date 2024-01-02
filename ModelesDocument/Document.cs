namespace ModelesDocument
{
   internal class Document
   {
      #region Propriétés
      private static readonly List<Document> Modeles;
      public string Titre { get; set; } = string.Empty;
      public Personne? Auteur { get; set; }
      public DateTime DateCreation { get; set; } = DateTime.Now;
      public (double Haut, double Bas, double Gauche, double Droite) Marges { get; set; }
      public string PiedDePage => $"{Auteur?.Nom ?? "Societeé XYZ"} - {Titre} - créé le : {DateCreation:d}";
      #endregion


      #region Constructeur
      static Document()
      {
         Modeles = new List<Document>
         {
            new Document
            {
               Titre = "Modèle A",
               DateCreation = new DateTime(2023, 01, 01),
               Marges = (2.5, 2.5, 1.5, 1.5)
            },
                 new Document
            {
               Titre = "Modèle B",
               DateCreation = new DateTime(2023,06, 30),
               Marges = (2, 2, 1, 1)
            },
         };

      }
      #endregion

      #region methodes 

      public static Document? CreerDepuisModele(string titreModele, Personne? auteur = null)
      {
         Document? document = null;
         var modelRecherche = Modeles.FirstOrDefault(x => x.Titre.ToLower() == titreModele.ToLower());
         if (modelRecherche != null)
         {
            document = new Document
            {
               Titre = titreModele,
               Marges = modelRecherche.Marges,
               Auteur = auteur
            };

         }
         return document;
      }
      #endregion

   }






}
