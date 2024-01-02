using System.Globalization;

namespace Bibliotheque
{
   public class DAL
   {
      public static List<Livre> GetLivres(string chemin)
      {
         List<Livre> livres = new();
         string? ligne;
         string[] lignes = new string[6];
         int i = 0;
         string readText = File.ReadAllText(chemin);
         using StringReader reader = new(readText);

         while ((ligne = reader.ReadLine()) != null)
         {
            if (!string.IsNullOrEmpty(ligne))
            {
               string[] infos = ligne.Split(":");
               lignes[i] = infos[1];
               i++;
               if (i == 6)
               {
                  Livre livre = new(lignes[0], lignes[1], lignes[2], lignes[3], DateTime.Parse(lignes[4], CultureInfo.CurrentCulture), lignes[5]);
                  livres.Add(livre);
                  i = 0;
               }
            }

         }

         return livres;
      }

      public class Livre
      {
         public string ISBN { get; set; }
         public string Titre { get; set; } = string.Empty;
         public string Auteur { get; set; } = string.Empty;
         public string NomImage { get; set; } = string.Empty;
         public DateTime DatePublication { get; set; }
         public string Description { get; set; } = string.Empty;



         public Livre(string iSBN, string titre, string auteur, string nomImage, DateTime datePublication, string description)
         {
            ISBN = iSBN;
            Titre = titre;
            Auteur = auteur;
            DatePublication = datePublication;
            NomImage = nomImage;
            Description = description;
         }
      }



   }
}
