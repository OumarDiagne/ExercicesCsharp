using static Bibliotheque.DAL;

namespace Bibliotheque
{
   internal class Program
   {
      static void Main(string[] args)
      {
         // Obtient le chemin du dossier Mes documents :
         string dossierTravail = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         // Construit un chemin par combinaison de noms de dossiers
         string dossierBibliotheque = Path.Combine(dossierTravail, "Bibliotheque", "livres.txt");

         List<Livre> livres = GetLivres(dossierBibliotheque);
         foreach (var livre in livres)
         {
            Console.Write($" ISBN : {livre.ISBN} \n Titre : {livre.Titre} \n Auteur : {livre.Auteur} \n Image : {livre.NomImage} \n Publication : {livre.DatePublication} \n Description : {livre.Description} \n ");
            Console.Write("\n");
         }

         string fichierPage = Path.Combine(dossierTravail, "Bibliotheque", "livres.html");
         HTMLWriter.GénérerPage(livres, fichierPage);
      }
   }
}