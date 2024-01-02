namespace DistributeurBoissons
{
   public class Carte
   {
      public string CodeDistributeur { get; }
      public int Id { get; }
      public decimal Solde { get; set; }

      public Carte(string codeDistributeur, int id)
      {
         CodeDistributeur = codeDistributeur;
         Id = id;
      }
   }

   public enum TypesBoissons { Café, Chocolat, Thé }

   public class Boisson
   {
      public TypesBoissons Type { get; set; }
      public int DoseSucre { get; set; }
   }

   public class Distributeur
   {
      public static readonly decimal PRIX_BOISSON = 1m; // Prix des boissons
      public static readonly string CODE_DISTRI = "XYZ"; // Code distributeur pour vérif des cartes

      public static readonly int CAFE = 0, CHOCOLAT = 1, THE = 2, SUCRE = 3, EAU = 4, GOBELETS = 5;

      private int[] _stocks = new int[6]; // Stocks de café, chocolat, thé, sucre, eau et gobelets

      /// <summary>
      /// Recharge le distributeur avec le nombre d'unités spécifié
      /// pour le stock d'indice spécifié ou pour tous les stocks si indice = -1
      /// </summary>
      /// <param name="nbUnits">Nombre d'unités de recharge</param>
      /// <param name="indiceStock">Indice du stock (optionnel)</param>
      /// <exception cref="...">Nombre d'unités en dehors de la plage [0, 100],
      /// ou indice de stock en dehors de la plage [-1, 5]</exception>
      public void Recharger(int nbUnits, int indiceStock = -1)
      {
         // TODO : vérifier les valeurs des paramètres
         if (indiceStock < -1 || indiceStock > 5)
         {
            throw new ArgumentOutOfRangeException("Ce choix ne correspond à aucune action");
         }
         if (nbUnits < 0 || indiceStock > 100)
         {
            throw new ArgumentOutOfRangeException("le nombre d'unitè de recharge doit etre strictement positif compris entre 0 et 100.");
         }


         if (indiceStock >= 0)
         {
            _stocks[indiceStock] = nbUnits;
         }
         else
         {
            for (int i = 0; i < _stocks.Length; i++)
               _stocks[i] = nbUnits;
         }
      }

      /// <summary>
      /// Commande une boisson au distributeur
      /// </summary>
      /// <param name="carte">carte utilisée pour payer</param>
      /// <param name="type">type de boisson</param>
      /// <param name="doseSucre">dose de sucre</param>
      /// <returns>Boisson commandée</returns>
      public Boisson CommanderBoisson(Carte carte, TypesBoissons type, int doseSucre)
      {
         ValiderCarte(carte);
         VérifierStocks(type);
         DébiterCarte(carte, PRIX_BOISSON);
         Boisson boisson = PreparerBoisson(type, doseSucre);
         return boisson;
      }

      // Vérifie si le code distributeur de la carte est le bon
      // et émet une exception si ce n'est pas le cas
      private void ValiderCarte(Carte carte)
      {
         // TODO
         if (carte == null)
         {
            throw new UnauthorizedAccessException("carte non reconnue");
         }

         if (!carte.CodeDistributeur.Contains(CODE_DISTRI))
         {
            throw new UnauthorizedAccessException("carte non valide sur ce distributeur");
         }
      }

      // Vérifie que les stocks sont suffisants pour préparer la boisson demandée
      // et émet une exception si ce n'est pas le cas
      private void VérifierStocks(TypesBoissons typeBoisson)
      {
         // TODO
         if ((_stocks[(int)typeBoisson] == 0))
         {
            throw new InvalidOperationException($"le stock de {typeBoisson} est épuisé, veuillez recharger");
         }
         else if (_stocks[EAU] == 0)
         {
            throw new InvalidOperationException("stock d'eau insuffisant");
         }
         else if (_stocks[GOBELETS] == 0)
         {
            throw new InvalidOperationException("stock de gobelets insuffisant");
         }
      }

      // Débite la carte du montant demandé
      // ou émet une exception si le solde est insuffisant
      private void DébiterCarte(Carte carte, decimal montant)
      {
         // TODO
         if (carte == null)
         {
            throw new ArgumentNullException("carte invalide");
         }
         else
         {
            if (carte.Solde < montant)
            {
               throw new ArgumentException(" solde de carte insuffisant");
            }
         }
         carte.Solde -= montant;
      }

      // Prépare et renvoie la boisson demandée
      private Boisson PreparerBoisson(TypesBoissons type, int doseSucre = 3)
      {
         // Décrémente les stocks de boisoon, sucre, eau et gobelets
         _stocks[(int)type]--;

         if (doseSucre > _stocks[SUCRE])
         {
            doseSucre = _stocks[SUCRE];
            _stocks[SUCRE] = 0;
         }
         else
            _stocks[SUCRE] -= doseSucre;

         _stocks[EAU]--;
         _stocks[GOBELETS]--;

         // Prépare la boisson
         Boisson b = new() { Type = type, DoseSucre = doseSucre };
         return b;
      }
   }
}
