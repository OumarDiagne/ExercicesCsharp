namespace RelevesMeteos2
{
   public class DAL
   {
      public static SortedList<DateOnly, RelevéMensuel> GetRelevésMensuels()
      {
         string[] lignes = File.ReadAllLines("MeteoParis.csv");
         var listeTriee = new Dictionary<DateTime, Relevé>();
         for (int i = 1; i < lignes.Length; i++)
         {
            //simplifie le format des heures d'ensoleillement

            string ligne = lignes[i].Replace("h ", "h").Replace("min", "");

            //récupoère les infos de la ligne dans un tableau

            string[] infos = ligne.Split(";");

            int.TryParse(infos[0], out var mois);
            int.TryParse(infos[1], out var annee);
            int jour = DateTime.DaysInMonth(annee, mois);
            DateTime date = new DateTime(annee, mois, jour);


         }
         return new SortedList<DateOnly, RelevéMensuel>();
      }
   }
}
