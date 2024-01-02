namespace Services.UI
{
   public abstract class Page : IPage
   {


      public IPage? Parente { get; set; }
      public string Titre { get; set; } = string.Empty;

      public virtual void Afficher()
      {
         Console.Clear();
         Console.WriteLine($"{Titre}");
         Executer();
         Console.WriteLine("Appuyer sur la touche \"echap\" pour revenir au menu précédent");
         if (Console.ReadKey(true).Key == ConsoleKey.Escape)
         {
            if (Titre != "Accueil")
            {
               Parente = new PageAccueil();
               Parente.Afficher();
            }

         }
      }



      abstract protected void Executer();

   }
}
