using DistributeurBoissons;

namespace DistributeurBoissons_Tests
{
   [TestClass]
   public class TestsDistributeurBoissons
   {
      private readonly Distributeur unDistributeur = new();
      private readonly Carte maCarte = new(Distributeur.CODE_DISTRI, 1);

      [AssemblyInitialize]
      public static void AssemblyInitialize(TestContext testContext)
      {
      }

      [AssemblyCleanup]
      public static void AssemblyCleanup()
      {
      }
      [TestInitialize]
      public void TestInitialize()
      {
         maCarte.Solde = 50;
      }

      [TestCleanup]
      public void TestCleanup()
      {

      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentOutOfRangeException))]
      public void RechargerDistributeurNbUniteInferieur_0()
      {

         //recharge le distributeur avec une unit� negative , provoque une exception de type out of range
         unDistributeur.Recharger(-1, 0);
      }

      [TestMethod]
      public void CommanderChocolatSansErreur_DoseSucre_2()
      {
         //recharge le distributeur sur tous les stocks
         unDistributeur.Recharger(100, -1);
         Boisson commandeChocolatReussie = unDistributeur.CommanderBoisson(maCarte, TypesBoissons.Chocolat, 2);

         Assert.IsInstanceOfType(commandeChocolatReussie, typeof(Boisson));
         Assert.AreEqual(TypesBoissons.Chocolat, commandeChocolatReussie.Type);
         Assert.AreEqual(2, commandeChocolatReussie.DoseSucre);
      }

      [TestMethod]
      public void CommanderChocolatSansErreur_DoseSucreInsuffisant_2()
      {

         //recharge le distributeur sur tous les stocks de 2 unit�
         unDistributeur.Recharger(2, -1);
         Boisson commandeChocolatReussie = unDistributeur.CommanderBoisson(maCarte, TypesBoissons.Chocolat, 3);

         Assert.IsInstanceOfType(commandeChocolatReussie, typeof(Boisson));
         Assert.AreEqual(TypesBoissons.Chocolat, commandeChocolatReussie.Type);
         Assert.AreEqual(2, commandeChocolatReussie.DoseSucre);
      }

      [TestMethod]
      [ExpectedException(typeof(UnauthorizedAccessException))]
      public void CommanderChocolatSansErreur_CarteNonValide()
      {
         Carte maCarteInvalide = new("ABC", 2);
         maCarteInvalide.Solde = 50;
         //recharge le distributeur sur tous les stocks de 2 unit�
         unDistributeur.Recharger(50, -1);
         Boisson commandeChocolatReussie = unDistributeur.CommanderBoisson(maCarteInvalide, TypesBoissons.Chocolat, 3);


      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void CommanderChocolat_CarteSoldeInsuffisant()
      {
         maCarte.Solde = 0;
         //recharge le distributeur sur tous les stocks de 2 unit�
         unDistributeur.Recharger(50, -1);
         Boisson commandeChocolatReussie = unDistributeur.CommanderBoisson(maCarte, TypesBoissons.Chocolat, 3);


      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void CommanderBoisson_StockInsuffisant_cafe_la_deuxiemefois()
      {

         //recharge le distributeur sur tous les stocks de 2 unit�
         unDistributeur.Recharger(1, -1);
         Boisson commandeChocolatReussie = unDistributeur.CommanderBoisson(maCarte, TypesBoissons.Caf�, 3);
         Assert.AreEqual(TypesBoissons.Caf�, commandeChocolatReussie.Type);
         unDistributeur.Recharger(1, 5);
         unDistributeur.Recharger(3, 3);
         commandeChocolatReussie = unDistributeur.CommanderBoisson(maCarte, TypesBoissons.Caf�, 3);
         Assert.AreEqual(TypesBoissons.Caf�, commandeChocolatReussie.Type);

      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void CommanderBoisson_StockInsuffisant_cafe_chocolat_th�_eau_gobeluii()
      {

         //recharge le distributeur sur tous les stocks de 2 unit�
         unDistributeur.Recharger(0, -1);
         Boisson commandeChocolatReussie = unDistributeur.CommanderBoisson(maCarte, TypesBoissons.Th�, 3);


      }
   }

   /*  [TestClass]
public class TestDistributeur
{
   private Distributeur _distri;
   private Carte _carte;

   [TestInitialize]
   public void InitialiserTest()
   {
      _distri = new Distributeur(); // Distributeur vide
      _carte = new Carte("XYZ", 1); // Carte valide vide
   }

   [DataTestMethod]
   [DataRow(-1, -1, DisplayName = "Nb unit�s < 0")]
   [DataRow(101, -1, DisplayName = "Nb unit�s > 100")]
   [DataRow(100, -2, DisplayName = "indice de stock < -1")]
   [DataRow(100, 6, DisplayName = "indice de stock > 5")]
   [ExpectedException(typeof(ArgumentOutOfRangeException))]
   public void RechargerDistriDeFa�onIncorrect(int nbUnits, int indideStock)
   {
      _distri.Recharger(nbUnits, indideStock);
   }

   [TestMethod]
   public void CommandeOk()
   {
      TypesBoissons type = TypesBoissons.Chocolat;
      int doseSucre = 1;
      _carte.Solde = 5m;

      _distri.Recharger(10);
      Boisson b = _distri.CommanderBoisson(_carte, type, doseSucre);

      Assert.AreEqual(type, b.Type, "type de boisson");
      Assert.AreEqual(doseSucre, b.DoseSucre, "dose de sucre");
   }

   [TestMethod]
   public void CommandeOkMaisSucreInsuffisant()
   {
      TypesBoissons type = TypesBoissons.Chocolat;
      int doseSucre = 6;   // Nb d'unit�s de sucre demand�
      int unit�sSucreDistri = 5; // Nb d'unit�s de sucre restantes dans le distributeur
      _carte.Solde = 5m;

      _distri.Recharger(10);
      _distri.Recharger(unit�sSucreDistri, 3);
      Boisson b = _distri.CommanderBoisson(_carte, type, doseSucre);

      Assert.AreEqual(type, b.Type, "type de boisson");
      Assert.AreEqual(unit�sSucreDistri, b.DoseSucre, "dose de sucre");
   }

   [TestMethod]
   [ExpectedException(typeof(UnauthorizedAccessException))]
   public void CommandeAvecCarteNonValide()
   {
      Carte carte = new Carte("ABC", 0) { Solde = 3 };
      _distri.CommanderBoisson(carte, TypesBoissons.Th�, 2);
   }

   [TestMethod]
   [ExpectedException(typeof(ArgumentException))]
   public void CommandeAvecSoldeCarteInsuffisant()
   {
      _carte.Solde = 0m;
      _distri.Recharger(10);
      _distri.CommanderBoisson(_carte, TypesBoissons.Caf�, 0);
   }

   [DataTestMethod]
   [DataRow(0, DisplayName = "Stock de caf� vide")]
   [DataRow(1, DisplayName = "Stock de chocolat vide")]
   [DataRow(2, DisplayName = "Stock de th� vide")]
   [DataRow(4, DisplayName = "Stock d'eau vide")]
   [DataRow(5, DisplayName = "Stock de gobelets vide")]
   [ExpectedException(typeof(InvalidOperationException))]
   public void CommandeAvecStockInsuffisant(int indiceStock)
   {
      _distri.Recharger(1);   // Initialise tous les stocks � 1
      _distri.Recharger(0, indiceStock); // Vide le stock d'indice donn�
      TypesBoissons typeBoisson = TypesBoissons.Caf�;
      if (indiceStock < 3)
         typeBoisson = (TypesBoissons)indiceStock;
      int doseSucre = 0;

      _distri.CommanderBoisson(_carte, typeBoisson, doseSucre);
   }

   [TestMethod]
   [ExpectedException(typeof(InvalidOperationException))]
   public void CommandeOkPuisStockInsufisant()
   {
      TypesBoissons typeBoisson = TypesBoissons.Th�;
      int doseSucre = 2;

      _distri.Recharger(1);
      _carte.Solde = 2m;
      Boisson b = _distri.CommanderBoisson(_carte, typeBoisson, doseSucre);

      Assert.AreEqual(typeBoisson, b.Type, "type de boisson");
      Assert.AreEqual(1, b.DoseSucre, "dose de sucre");

      // Nouvelle commande du m�me type de boisson
      _distri.CommanderBoisson(_carte, typeBoisson, doseSucre);
   }
}     */
}