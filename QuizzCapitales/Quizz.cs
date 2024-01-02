namespace QuizzCapitales
{
   internal class Quizz
   {
      static string[] paysTab = { "Albanie", "Allemagne", "Andorre", "Autriche", "Belgique", "Biélorussie", "Bosnie-Herzégovine", "Bulgarie", "Chypre", "Croatie" };
      static string[] capitalesTab = { "Tirana", "Berlin", "Andorre-la-Vieille", "Vienne", "Bruxelles", "Minsk", "Sarajevo", "Sofia", "Nicosie", "Zagreb" };
      static int compteur;
      static string? rejouer;

      public static void Jouer()
      {

         do
         {
            Console.Clear();
            compteur = 0;

            for (int i = 0; i < paysTab.Length; i++)
            {
               if (PoserQuestion(i))
               {
                  compteur++;
               }
               Console.WriteLine();
            }
            Console.WriteLine($" vous totalisez {compteur} bonnes réponses. ");

         }
         while (DemanderSiRejouer());
      }

      static bool PoserQuestion(int indice)
      {
         bool estReponseOk = false;
         Console.WriteLine($"Quelle est la capitale de {paysTab[indice]} ?");
         string? rep = Console.ReadLine();
         if (rep != null)
         {
            if (rep.ToLower() == capitalesTab[indice].ToLower())
            {
               Console.WriteLine("Bravo !");
               estReponseOk = true;
            }
            else
            {
               Console.WriteLine($"Mauvaise réponse.La réponse était {capitalesTab[indice]}");

            }
         }
         return estReponseOk;
      }

      static bool DemanderSiRejouer()
      {
         bool estRejouerOk = true;
         Console.WriteLine("Voulez vous rejouer ? : O/N");
         rejouer = Console.ReadLine();
         if (rejouer != null)
         {
            if (rejouer.ToLower() != "o".ToLower())
            {
               Console.WriteLine("merci d'avoir joué ! ");
               estRejouerOk = false;
            }
         }
         return estRejouerOk;
      }

      public static void Jouer(params int[] numeroQuestion)
      {
         do
         {
            Console.Clear();
            compteur = 0;

            for (int i = 0; i < numeroQuestion.Length; i++)
            {
               if (numeroQuestion[i] > 0 && numeroQuestion[i] <= 10)
                  if (PoserQuestion(numeroQuestion[i] - 1))
                  {
                     compteur++;
                  }
               Console.WriteLine();
            }
            Console.WriteLine($" vous totalisez {compteur} bonnes réponses. ");

         }
         while (DemanderSiRejouer());
      }


      public static (int, int, int) Generer3Numeros()
      {
         Random rand = new Random();
         (int, int, int) tuple = (rand.Next(1, 11), rand.Next(1, 11), rand.Next(1, 11));
         return tuple;
      }
      static int SaisirNombre(int min, int max)
      {
         bool estUnNombre = false, saisieNombreCorrecte = false;
         int nombre = 0;
         while (!saisieNombreCorrecte)
         {

            Console.WriteLine($"Saisir un numero entre la valeur min {min} et la valeur max {max}");
            string? Saisie = Console.ReadLine();
            if ((Saisie != null))
            {
               estUnNombre = int.TryParse(Saisie, out nombre);
               if (nombre >= min && nombre <= max && estUnNombre)
               {
                  saisieNombreCorrecte = true;

               }
               else
               {
                  Console.WriteLine("\nmauvaise saisie");
               }
            }
         }
         return nombre;

      }

      public static (int, int, int) Saisir3Numeros(int min, int max)
      {
         int[] tab = new int[3];
         for (int i = 0; i < 3; i++)
         {
            tab[i] = SaisirNombre(min, max);
         }
         return (tab[0], tab[1], tab[2]);
      }
   }
}

