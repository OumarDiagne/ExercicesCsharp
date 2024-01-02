namespace Boites
{
   internal class Program
   {
      static void Main(string[] args)
      {
         //Console.WriteLine("Hello, Boites!");
         //Boite uneBoite = new Boite();
         //Console.WriteLine($"\nvolume de la boite : {uneBoite.Volume}, de matière : {uneBoite.Matiere}");


         //Console.WriteLine($"\n uneboite a destination de : {uneBoite.EtiquetteColis}, de contenu : {(uneBoite.Fragile ? "fragile" : "pas fragile")}");

         Boite boite = new Boite(10, 30, 20);
         //Console.WriteLine($"\n boite a destination de : {boite.EtiquetteColis}, de contenu : {(boite.Fragile ? "fragile" : "pas fragile")}");

         Boite boite2 = new Boite(24, 20, 30, Matieres.Bois);
         //Boite boite3 = new Boite(3, 2, 1, Matieres.Bois);
         //Console.WriteLine($"\n boite2 a destination de : {boite2.Volume}, de contenu : {(boite2.Fragile ? "fragile" : "pas fragile")}");
         //Console.WriteLine($"\n boites crees  : {Boite.NbBoites}");

         //Console.WriteLine($"\n boite et boite2 identique ?  : {Boite.Comparer(boite, boite2)}");
         //Console.WriteLine($"\n boite3 et boite2 identique ?  : {Boite.Comparer(boite3, boite2)}");
         //Console.WriteLine($"\n boite3 et boite2 identique ?  : {boite3.Comparer(boite2)}");
         //boite.Etiqueter("M. Dupont Eric, 3 rue Victor Hugo - 87000 Limoges", 1123456789);


         //if (boite.EtiquetteColis != null)
         //   Console.WriteLine($"{boite.EtiquetteColis.Destinataire} ");
         //else Console.WriteLine("boite n a ^pas d etiquette");

         //if (boite2.EtiquetteColis != null)
         //   Console.WriteLine($"{boite2.EtiquetteColis.Destinataire} ");
         //else Console.WriteLine("boite2 n a ^pas d etiquette");

         //Client client = new Client() { Adresse = " 3 rue Victor Hugo - 87000 Limoges", Nom = "Dupont", Prenom = "Eric", NumeroClient = 11123345 };
         //boite.Etiqueter(client, 123456789);
         //if (boite.EtiquetteColis != null && boite.EtiquetteColis.Destinataire != null)
         //   Console.WriteLine($"""
         //    Colis N° {boite.EtiquetteColis.NumeroColis}
         //    Destinataire : M. {boite.EtiquetteColis.Destinataire.Nom} {boite.EtiquetteColis.Destinataire.Prenom} , {boite.EtiquetteColis.Destinataire.Adresse}
         //    {(boite.Fragile ? "fragile" : "pas fragile")}
         //    """

         // );

         Article a = new Article() { Libelle = "lot de 6 assiettes plates", Volume = 4000 };
         Article b = new Article() { Libelle = "lot de 12 couverts", Volume = 1000 };
         Article c = new Article() { Libelle = "lot de 6 bols", Volume = 2000 };
         boite.TryAddArticle(a);

         Console.WriteLine(boite.Description);
         boite.TryAddArticle(b);

         Console.WriteLine(boite.Description);
         boite.TryAddArticle(c);
         Console.WriteLine(boite2.Description);

         Console.WriteLine(boite.Description);

         Boite.TransfererBoite(boite, boite2);
         Console.WriteLine(boite.Description);
         Console.WriteLine(boite2.Description);

      }



   }
}