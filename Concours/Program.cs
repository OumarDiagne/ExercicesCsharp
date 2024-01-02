namespace Concours
{
   internal class Program
   {

      static void Main(string[] args)
      {
         Console.WriteLine("Contest result!");
         DAL.ChargerDonnées();
         AfficherRésultatsConcours();
         Console.ReadKey();
         Console.Clear();
         Console.WriteLine();
         AfficherEtudiantsEtrangerAdmis();
         Console.ReadKey();
         Console.Clear();
         Console.WriteLine();
         AfficherEtudiantsFrançaisBoursiers();

      }

      public static void AfficherRésultatsConcours()
      {
         var compteur = 0;
         if (DAL.ETUDIANTS != null)
         {
            for (int i = 1; i < DAL.ETUDIANTS.Length; i++)
            {
               if (DAL.ETUDIANTS[i].status.HasFlag(DAL.Status.Admis))
               {
                  compteur++;
                  Console.WriteLine($"{DAL.ETUDIANTS[i].nom,-20}:   {DAL.ETUDIANTS[i].moyenne,5}  {Notation.mention[(int)Notation.GetMention(DAL.ETUDIANTS[i].moyenne)],-10}    Admis  ");

               }
               else Console.WriteLine($"{DAL.ETUDIANTS[i].nom,-20}:   {DAL.ETUDIANTS[i].moyenne,5}  {Notation.mention[(int)Notation.GetMention(DAL.ETUDIANTS[i].moyenne)],-10}         ");
            }
            Console.WriteLine($"Total : {compteur} étudiants admis\n");
         }
      }

      public static void AfficherEtudiantsEtrangerAdmis()
      {
         var compteur = 0;
         Console.WriteLine("Etudiants étrangers admis :\n");
         if (DAL.ETUDIANTS != null)
         {
            for (int i = 1; i < DAL.ETUDIANTS.Length; i++)
            {
               if (DAL.ETUDIANTS[i].status.HasFlag(DAL.Status.Admis | DAL.Status.Etranger))
               {
                  compteur++;
                  Console.WriteLine($"{DAL.ETUDIANTS[i].nom,-20}");
               }

            }
            Console.WriteLine($"Total : {compteur} étudiants étrangers admis");
         }
      }

      public static void AfficherEtudiantsFrançaisBoursiers()
      {
         var compteur = 0;
         Console.WriteLine("Etudiants francais boursiers admis :\n");
         if (DAL.ETUDIANTS != null)
         {
            for (int i = 1; i < DAL.ETUDIANTS.Length; i++)
            {
               if (DAL.ETUDIANTS[i].status.HasFlag(DAL.Status.Francais | DAL.Status.Boursier))
               {
                  compteur++;
                  Console.WriteLine($"{DAL.ETUDIANTS[i].nom,-20}");
               }

            }
            Console.WriteLine($"Total : {compteur} étudiants français boursiers");
         }

      }
   }
}

/************************************************************************************************************************************************************/
//   static void Main(string[] args)
//   {
//      DAL.ChargerDonnées();
//      AfficherRésultatsConcours();
//      Console.ReadKey();
//      Console.Clear();

//      AfficherEtudiantsEtrangersAdmis();
//      Console.ReadKey();
//      Console.Clear();

//      AfficherEtudiantsFrançaisBoursiers();
//      Console.ReadKey();
//      Console.Clear();

//      string[] remplacés = { "Douglas Léa", "Cartier Claude", "Leduc Justin" };
//      string[] remplaçants = DAL.RemplacerEtudiantsAdmis(remplacés);
//      for (int r = 0; r < remplacés.Length; r++)
//      {
//         Console.WriteLine($"Remplacement de {remplacés[r]} par {remplaçants[r]}");
//      }
//      Console.WriteLine();
//      AfficherRésultatsConcours();
//      Console.ReadKey();
//   }

//   /// <summary>
//   /// Affiche le texte passé en paramètre avec la couleur spécifiée
//   /// </summary>
//   /// <param name="texte">texte à afficher</param>
//   /// <param name="couleur">couleur de police à utiliser</param>
//   static void AfficherTexte(string texte, ConsoleColor couleur = ConsoleColor.Blue)
//   {
//      ConsoleColor couleurOrigine = Console.ForegroundColor;
//      Console.ForegroundColor = couleur;
//      Console.WriteLine(texte);
//      Console.ForegroundColor = couleurOrigine;
//   }

//   // Affiche les résultats du concours (étudiants avec leurs moyennes et mentions)
//   static void AfficherRésultatsConcours()
//   {
//      if (DAL.Etudiants == null) return;

//      AfficherTexte($"Résultats du concours :\n");
//      for (int i = 0; i < DAL.Etudiants.Length; i++)
//      {
//         (Mentions mention, string libellé) mention = Notation.GetMention(DAL.Etudiants[i].moyenne);
//         string res = DAL.Etudiants[i].statuts.HasFlag(Statuts.Admis) ? "Admis" : string.Empty;

//         Console.WriteLine($"{DAL.Etudiants[i].nom,-20} : {DAL.Etudiants[i].moyenne,5:N1}  {mention.libellé,-12} {res}");
//      }

//      AfficherTexte($"\n{DAL.NbAdmis} étudiants admis sur {DAL.Etudiants.Length}", ConsoleColor.DarkGreen);
//   }

//   // Affiche les noms des étudiants étranger admis à l'école
//   static void AfficherEtudiantsEtrangersAdmis()
//   {
//      if (DAL.Etudiants == null) return;

//      AfficherTexte("Etudiants étrangers admis :\n");
//      int cpt = 0;

//      for (int i = 0; i < DAL.Etudiants.Length; i++)
//      {
//         if (DAL.Etudiants[i].statuts.HasFlag(Statuts.Etranger | Statuts.Admis))
//         {
//            cpt++;
//            Console.WriteLine($"{DAL.Etudiants[i].nom,-20}");
//         }
//      }

//      AfficherTexte($"\nTotal : {cpt} étudiants étrangers admis", ConsoleColor.DarkGreen);
//   }

//   // Affiche la liste des étudiants français boursiers
//   static void AfficherEtudiantsFrançaisBoursiers()
//   {
//      if (DAL.Etudiants == null) return;

//      AfficherTexte("Etudiants français boursiers :\n");
//      int cpt = 0;

//      for (int i = 0; i < DAL.Etudiants.Length; i++)
//      {
//         if (!(DAL.Etudiants[i].statuts.HasFlag(Statuts.Etranger)) &
//            DAL.Etudiants[i].statuts.HasFlag(Statuts.Boursier))
//         {
//            cpt++;
//            Console.WriteLine($"{DAL.Etudiants[i].nom,-20}");
//         }
//      }

//      AfficherTexte($"\nTotal : {cpt} étudiants français boursiers", ConsoleColor.DarkGreen);
//   }
//}
//}