using System.Text.RegularExpressions;

namespace TelechargeurImages
{
   public static class Telechargeur
   {

      private static readonly HttpClient client = new HttpClient();
      public static async Task<string[]> GetUrlsImages(string url)
      {

         HttpRequestMessage req = new(HttpMethod.Get, url);
         HttpResponseMessage reponse = await client.SendAsync(req);
         var result = await reponse.Content.ReadAsStringAsync();
         var matches = Regex.Matches(result, @"=""(?<image>https://[^:]*(\.jpg|.jpeg))""");

         // Extrait les urls des résultats
         string[] urls = matches.Select(m => m.Groups["image"].Value).Distinct().ToArray();
         return urls;
      }

      public static async Task<string> TelechargerImage(string url)
      {

         //obtient le lfux du fichier en telechargement
         using Stream stream = await client.GetStreamAsync(url);

         //charge l'image en mémoire depuis le flux
         Image img = await Image.LoadAsync(stream);

         //encode l'image en webp et l'enregistre dans un fichier
         string nomImage = Path.GetFileNameWithoutExtension(url) + ".webp";

         await img.SaveAsWebpAsync(nomImage);

         return nomImage;
      }
   }
}
