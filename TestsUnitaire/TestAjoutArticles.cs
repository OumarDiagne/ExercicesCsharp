namespace TestsUnitaire
{
   [TestClass]
   public class TestAjoutArticles
   {
      [TestMethod]
      public void TestAjout1Article()
      {
         Boite b = new Boite(50, 20, 10);
         Article a = new Article { Libelle = "zampakuto", Volume = 100 };
         var d = b.TryAddArticle(a);

         // Verifie qu'une boite créee par defaut a un volume de 9000
         Assert.IsTrue(d);
         Assert.IsInstanceOfType(b.Articles[0], typeof(Article));
         Assert.IsNotNull(b.Articles[0]);


      }
      [TestMethod]
      public void TestAjout2Article()
      {
         Boite b = new Boite(50, 20, 10);
         Article a = new Article { Libelle = "zampakuto", Volume = 100 };
         Article a1 = new Article { Libelle = "kido", Volume = 50 };
         var d = b.TryAddArticle(a);
         var e = b.TryAddArticle(a1);
         // Verifie qu'une boite créee par defaut a un volume de 9000
         Assert.IsTrue(d);
         Assert.IsTrue(e);
         Assert.IsInstanceOfType(b.Articles[0], typeof(Article));
         Assert.IsInstanceOfType(b.Articles[1], typeof(Article));
         Assert.IsNotNull(b.Articles[0]);
         Assert.IsNotNull(b.Articles[1]);
      }
      [TestMethod]
      public void TestAjout1ArticleBoiteTropPetite()
      {
         Boite b = new Boite(50, 20, 10);
         Article a = new Article { Libelle = "zampakuto", Volume = 1000000 };
         //Article a1 = new Article { Libelle = "kido", Volume = 50 };
         var d = b.TryAddArticle(a);
         //var e = b.TryAddArticle(a1);
         // Verifie qu'une boite créee par defaut a un volume de 9000
         Assert.IsFalse(d);
         //Assert.IsTrue(e);

         //Assert.IsInstanceOfType(b.Articles[1], typeof(Article));
         Assert.AreEqual(b.Articles.Count, 0);
         //Assert.IsNotNull(b.Articles[1]);
      }

      [TestMethod]
      public void TestAjout2ArticlesPlacePour1SeulArticle()
      {
         Boite b = new Boite(50, 20, 10);
         Article a = new Article { Libelle = "zampakuto", Volume = 1000000 };
         Article a1 = new Article { Libelle = "kido", Volume = 50 };
         var d = b.TryAddArticle(a);
         var e = b.TryAddArticle(a1);
         // Verifie qu'une boite créee par defaut a un volume de 9000
         Assert.IsFalse(d);
         Assert.IsTrue(e);

         Assert.IsInstanceOfType(b.Articles[0], typeof(Article));
         Assert.AreEqual(b.Articles.Count, 1);
         Assert.IsNotNull(b.Articles[0]);
      }

      [DataTestMethod]
      [DataRow(10, 14, 2, DisplayName = "2 articles transférés")]
      [DataRow(20, 10, 1, DisplayName = "1 seul article transféré")]
      [DataRow(25, 30, 0, DisplayName = "aucun article transféré")]
      public void TransférerArticlesentreBoites(double volArticle1, double volArticle2, int nbTransf)
      {
         Boite b1 = new Boite(3, 4, 5);
         Boite b2 = new Boite(2, 3, 4);
         Article a1 = new Article { Libelle = "Article1", Volume = volArticle1 };
         Article a2 = new Article { Libelle = "Article2", Volume = volArticle2 };


         b1.TryAddArticle(a1);
         b1.TryAddArticle(a2);
         int res = Boite.TransfererBoite(b1, b2);

         Assert.AreEqual(nbTransf, res, "Nombre articles transférés");
         //Assert.AreEqual(2 - nbTransf, b1.Articles.Count, "Articles restants dans boîte 1");
         //Assert.AreEqual(nbTransf, b2.Articles.Count, "Articles dans boîte 2");
      }
   }
}

