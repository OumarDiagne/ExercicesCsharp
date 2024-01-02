using Services.UI;

namespace Services
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello, Services!");
         PageAccueil pageAccueil = new();
         pageAccueil.Afficher();


      }
   }
}