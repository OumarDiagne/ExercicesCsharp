using System.Collections.ObjectModel;

namespace Boites
{
   public class Boite
   {
      #region Constantes et variables
      public const double VALEUR_Init = 30.0;


      #endregion

      #region Propriétés Publiques
      private List<Article> _articles { get; set; } = new List<Article>();
      public double Hauteur { get; } = VALEUR_Init;
      public double Largeur { get; } = VALEUR_Init;
      public double Longeur { get; } = VALEUR_Init;
      public Matieres Matiere { get; } = Matieres.Carton;
      public bool Fragile { get; private set; }
      public double Volume => Hauteur * Largeur * Longeur;
      public double VolumeRestant { get; private set; }
      public Etiquette EtiquetteColis { get; private set; }
      public ReadOnlyCollection<Article> Articles => _articles.AsReadOnly();
      public string Description =>
                 $"""
                  Boite de volume {Volume} en {Matiere} contenant :
                  """ + AfficheListeArticle();



      public static int NbBoites { get; private set; }

      #endregion

      #region Constructeurs

      public Boite()
      {
         NbBoites++;
      }
      public Boite(double hauteur, double largeur, double longeur)
      {
         NbBoites++;
         Hauteur = hauteur;
         Largeur = largeur;
         Longeur = longeur;
         VolumeRestant = Volume;
      }

      public Boite(double hauteur, double largeur, double longeur, Matieres matiere) : this(hauteur, largeur, longeur)
      {
         Matiere = matiere;
      }
      #endregion

      #region Méthodes d'instances
      public void Etiqueter(Client destinataire, int numeroColis)
      {
         EtiquetteColis = new Etiquette() { Couleur = Couleurs.Blanc, Format = Formats.XL, Destinataire = destinataire, NumeroColis = numeroColis };

      }
      public void Etiqueter(Client destinataire, bool Estfragile, int numeroColis)
      {
         Fragile = Estfragile;
         Etiqueter(destinataire, numeroColis);
      }

      public bool Comparer(Boite a)
      {
         //  return (a.Volume == this.Volume && a.Matiere == this.Matiere);
         return Comparer(a, this);

      }
      public bool TryAddArticle(Article a)
      {

         if (a != null)
         {
            if (a.Volume <= VolumeRestant)
            {
               _articles.Add(a);
               VolumeRestant -= a.Volume;
               return true;
            }
         }
         return false;
      }


      #endregion

      #region Methodes Privées

      private string AfficheListeArticle()
      {
         string temp = string.Empty;
         foreach (var item in Articles)
         {
            temp += $"\n- lot de {item.Libelle}";
         }
         return temp;
      }
      #endregion

      #region Methodes Statiques
      public static bool Comparer(Boite a, Boite b)
      {
         if (a == null || b == null) return false;
         else if (a.Volume == b.Volume && a.Matiere == b.Matiere) return true;
         else return false;
      }

      /// <summary>
      /// transfert le contenu de a vers b
      /// </summary>
      /// <param name="a"></param>
      /// <param name="b"></param>
      public static int TransfererBoite(Boite a, Boite b)
      {
         int compteur = 0;
         if (a == null || b == null)
         {
            Console.WriteLine("tranfert impossible ,au moins une de ces boite n'existe pas");
            return 0;
         }


         for (int i = a.Articles.Count - 1; i >= 0; i--)
         {
            if (b.TryAddArticle(a.Articles[i]))
            {
               a._articles.RemoveAt(i);
               compteur++;
            }

         }
         Console.WriteLine($"\n{compteur} articles ont ètè tranferés");
         return compteur;
      }
      #endregion

   }

   public enum Matieres { Carton, Plastique, Bois, Metal }
}


