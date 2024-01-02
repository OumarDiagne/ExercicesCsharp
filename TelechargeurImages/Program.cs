namespace TelechargeurImages
{
   internal class Program
   {


      static async Task Main(string[] args)
      {
         string dossierTravail = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
         string dossierImage = Path.Combine(dossierTravail, "ImagesWeb");
         Directory.SetCurrentDirectory(dossierImage);
         string[] result = await Telechargeur.GetUrlsImages("https://jardinage.lemonde.fr/dossiers-cat2-36-oiseaux.html");
         

         foreach (string url in result)
         {
            var nom = await Telechargeur.TelechargerImage(url);
            Console.WriteLine("Image téléchargée: " + nom);
         }
      }
   }
}