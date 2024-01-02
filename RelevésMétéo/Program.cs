namespace RelevésMétéo
{
   internal class Program
   {
      static void Main(string[] args)
      {
         // AfficherListe();
         AfficherTableau();
      }

      static void AfficherListe()
      {
         string[] lignes = File.ReadAllLines("MeteoParis.csv");
         float sommeTemp = 0f;

         for (int i = 1; i < lignes.Length; i++)
         {
            //simplifie le format des heures d'ensoleillement

            string ligne = lignes[i].Replace("h ", "h").Replace("min", "");

            //récupoère les infos de la ligne dans un tableau

            string[] infos = ligne.Split(";");

            //construit une ligne sous la forme souhaitée

            Console.WriteLine($"{infos[0]}/{infos[1]} | {infos[2],6:N1} | {infos[3],6:N1} | {infos[6],7}| {infos[7],10:N1} ");

            // Ajoute la temperature moy au cumul
            if (float.TryParse(infos[4], out float temp))
            {
               sommeTemp += temp;
            }

            //Mois; Année; TMin_(°C); TMax_(°C); TMoy_(°C); VentMax_(km / h); Soleil_(h); Pluie_(mm)
            // 06;2013;9,9;28,7;16,9;77,8;59h 30min;28,8
            // 06 / 2013 : [9,9; 28,7]°C        59h30 de soleil 28,8 mm de pluie

         }
         Console.WriteLine();
         Console.WriteLine($"T° moy : {sommeTemp / (lignes.Length - 1)}");
      }

      static void AfficherTableau()
      {
         const string entetes = """
               Mois | T° min | T° max | Soleil | Pluie (mm)
            -----------------------------------------------
            """;
         Console.WriteLine(entetes);

         AfficherListe();
      }
   }
}