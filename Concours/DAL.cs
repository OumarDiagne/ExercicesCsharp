namespace Concours
{
   public class DAL
   {
      public static (string nom, double moyenne, Status status)[]? ETUDIANTS;
      public const int NbAdmis = 50;
      [Flags] public enum Status { Francais = 1, Etranger = 2, Boursier = 4, Admis = 8 };

      public static void ChargerDonnées()
      {
         string[] lignes = File.ReadAllLines("Etudiants.csv");
         int compteur = 1;

         if (lignes != null && lignes.Length > 0)
         {
            (string nom, double moyenne, Status status)[] tab = new (string, double, Status)[lignes.Length];
            for (int i = 1; i < lignes.Length; i++)
            {
               //récupoère les infos de la ligne dans un tableau

               string[] infos = lignes[i].Split(";");

               //construit une ligne sous la forme souhaitée

               if (infos != null && infos.Length > 0)
               {

                  tab[i].nom = infos[0] + " " + infos[1];
                  tab[i].status = GetStatus(infos[2] + infos[3]);
                  tab[i].moyenne = double.Parse(infos[infos.Length - 1]);
               }
               if (compteur <= NbAdmis)
               {
                  tab[i].status |= Status.Admis;
               }
               compteur++;
            }
            ETUDIANTS = tab;
         }


      }

      private static Status GetStatus(string status)
      {
         switch (status)
         {
            case "OO":
               return Status.Etranger | Status.Boursier;

            case "ON":
               return Status.Etranger;

            case "NO":
               return Status.Francais | Status.Boursier;
            case "NN":
               return Status.Francais;
            default: return Status.Etranger;

         }
      }


      /// <summary>
      /// Remplace un ou plusieurs étudiants admis par les premiers non admis
      /// </summary>
      /// <param name="noms">noms des étudiants à remplacer</param>
      /// <returns>Tableau des noms des remplaçants</returns>
      public static string[] RemplacerEtudiantsAdmis(params string[] noms)
      {
         // Initialise le tableau et le compteur de remplaçants
         string[] remplaçants = new string[noms.Length];
         int cptRemp = 0;

         if (ETUDIANTS == null) return remplaçants;

         // Pour chaque étudiant à remplacer
         for (int n = 0; n < noms.Length; n++)
         {
            // On recherche l'étudiant dans la liste
            for (int i = 0; i < NbAdmis; i++)
            {
               if (ETUDIANTS[i].nom == noms[n])
               {
                  // On enlève le statut admis de l'étudiant
                  ETUDIANTS[i].status ^= Status.Admis;

                  // On ajoute le statut Admis au premier non admis
                  // et on enregistre son nom dans le tableau des remplaçants
                  ETUDIANTS[NbAdmis + cptRemp].status |= Status.Admis;
                  remplaçants[n] = ETUDIANTS[NbAdmis + cptRemp].nom;

                  // On incrémente le compteurs de remplaçants et on sort de la boucle
                  cptRemp++;
                  break;
               }
            }
         }
         return remplaçants;
      }
   }

}





