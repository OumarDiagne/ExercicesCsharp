namespace Services.UI
{
   public interface IPage
   {
      IPage? Parente { get; set; }
      string Titre { get; set; }

      void Afficher();
   }
}
