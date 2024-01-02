namespace Concours
{

   internal class Notation
   {
      public static string[] mention = { "Echec", "Passable", "Assez bien", "Bien", "Très bien" };
      public enum Mention { Echec, Passable, Assezbien, Bien, Trèsbien };

      public static Mention GetMention(double note)
      {
         if (note >= 16)
         {
            return Mention.Trèsbien;
         }
         else if (note < 16.0 && note >= 14.0)
         {
            return Mention.Bien;
         }
         else if (note < 14.0 && note >= 12.0)
         {
            return Mention.Assezbien;
         }
         else if (note < 12.0 && note >= 10.0)
         {
            return Mention.Passable;
         }
         else return Mention.Echec;

      }


      //internal enum Mentions { E = 0, P = 10, AB = 12, B = 14, TB = 16 }

      //internal class Notation
      //{
      //   static string[] LibellésMentions = { "Echec", "Passable", "Assez bien", "Bien", "Très bien" };

      //   public static (Mentions, string) GetMention(double note)
      //   {
      //      Mentions mention = Mentions.E;
      //      string libellé = LibellésMentions[0];

      //      int cpt = 0;
      //      foreach (Mentions m in Enum.GetValues(typeof(Mentions)))
      //      {
      //         if ((int)m <= note)
      //         {
      //            mention = m;
      //            libellé = LibellésMentions[cpt++];
      //         }
      //         else
      //            break;
      //      }

      //      return (mention, libellé);
      //   }
      //}
   }
}
