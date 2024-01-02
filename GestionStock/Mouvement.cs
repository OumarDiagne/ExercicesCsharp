namespace GestionStock
{
   public enum Type { Entree, Sortie, RAZ }


   public class Mouvement
   {
      public Type Type { get; set; }
      public DateTime Date { get; set; }
      public int Quantite { get; set; }
   }
}
