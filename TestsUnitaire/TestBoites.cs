
namespace TestsUnitaire
{
   [TestClass]
   public class TestBoites
   {
      [TestMethod]
      public void TesterCreationBoite()
      {
         Boite a = new Boite(10, 52, 13);


         // Verifie qu'une boite créee par defaut a un volume de 9000
         Assert.AreEqual(10 * 52 * 13, a.Volume);
         Assert.AreEqual(Matieres.Carton, a.Matiere);

      }
      [TestMethod]
      public void TesterCreationBoiteMatieres()
      {
         Boite a = new Boite(5, 7, 9, Matieres.Plastique);


         // Verifie qu'une boite créee par defaut a un volume de 9000
         Assert.AreEqual(5 * 7 * 9, a.Volume);
         Assert.AreEqual(Matieres.Plastique, a.Matiere);
      }

      [TestMethod]
      public void TesterCreationEtiquetageClientBoiteNonFragile()
      {
         Boite a = new Boite(5, 7, 9, Matieres.Plastique);
         Client c = new Client() { Nom = "inchimaru", Prenom = "gin", Adresse = "Serettei ", NumeroClient = 3 };
         a.Etiqueter(c, 339);

         // Verifie qu'une boite créee par defaut a un volume de 9000
         Assert.IsNotNull(a.EtiquetteColis);
         Assert.AreEqual(3, a.EtiquetteColis.Destinataire.NumeroClient);
         Assert.AreEqual(339, a.EtiquetteColis.NumeroColis);
         Assert.AreEqual(Couleurs.Blanc, a.EtiquetteColis.Couleur);
         Assert.AreEqual(Formats.XL, a.EtiquetteColis.Format);


      }
      [TestMethod]
      public void TesterCreationEtiquetageClientBoiteFragile()
      {
         Boite a = new Boite(5, 7, 9, Matieres.Plastique);
         Client c = new Client() { Nom = "inchimaru", Prenom = "gin", Adresse = "Serettei ", NumeroClient = 3 };
         a.Etiqueter(c, true, 339);

         // Verifie qu'une boite créee par defaut a un volume de 9000
         Assert.IsNotNull(a.EtiquetteColis);
         Assert.AreEqual(3, a.EtiquetteColis.Destinataire.NumeroClient);
         Assert.AreEqual(339, a.EtiquetteColis.NumeroColis);
         Assert.AreEqual(Couleurs.Blanc, a.EtiquetteColis.Couleur);
         Assert.AreEqual(Formats.XL, a.EtiquetteColis.Format);
         Assert.AreEqual(true, a.Fragile);


      }
   }
}