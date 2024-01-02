namespace Services.UI
{
   public class PageAccueil : Page
   {
      public PageAccueil()
      {
         Titre = "Accueil";
      }
      public override void Afficher()
      {
         Console.Clear();
         Console.WriteLine($"""
            Accueil
            ------------------------------
            0 : Quitter l'application
            1 : Factures simples
            2 : Factures de situation

            Votre choix ?
            """);
         Executer();
      }

      protected override void Executer()
      {
         IPage page;
         IServiceFacture service = new ServiceFacture();
         int choix;
         bool estUnNombre;
         do
         {


            Console.WriteLine("Choississez un menu entre 0 , 1 et 2:");
            estUnNombre = int.TryParse(Console.ReadLine(), out choix);

            if (estUnNombre)
            {
               if (choix == 0)
               {
                  Console.WriteLine("\nfin du services \n");
                  Environment.Exit(0);
               }

               if (choix == 1)
               {
                  page = new PageFacture(service);
                  page.Afficher();
               }
               if (choix == 2)
               {
                  page = new PageFactureSituation(service);
                  page.Afficher();
               }
            }





         } while (choix < 0 || choix > 2 || !estUnNombre);

      }
   }
}
