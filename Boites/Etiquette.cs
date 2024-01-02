namespace Boites
{
   public enum Couleurs { Blanc, Bleu, Vert, Jaune, Orange, Rouge, Marron, Noir }
   public enum Formats { XS, S, M, L, XL }
   public class Etiquette
   {
      public required Client Destinataire { get; set; }
      public required Couleurs Couleur { get; set; }
      public required Formats Format { get; set; }
      public long NumeroColis { get; set; }


   }
}
