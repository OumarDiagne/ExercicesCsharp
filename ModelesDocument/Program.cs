namespace ModelesDocument
{
   internal class Program
   {
      static void Main(string[] args)
      {
         var auteurs = new Personne[3];
         auteurs[0] = new Personne("Durand", "Léo");
         auteurs[1] = new Personne("Ricaud", "Léa");

         string[] nomModeles = new string[] { "truc", "Modèle A", "modèle B" };

         for (int i = 0; i < auteurs.Length; i++)
         {
            Document? doc = Document.CreerDepuisModele(nomModeles[i], auteurs[i]);

            if (doc == null)
            {
               Console.WriteLine($"Aucun modèle trouvé avec le titre {nomModeles[i]}\n");
               continue;
            }

            Console.WriteLine($"""
            Document créé :
            Pied de page : {doc.PiedDePage}
            Marges : Haut={doc.Marges.Haut}cm, Bas={doc.Marges.Bas}cm

            """);
         }
      }
   }
}