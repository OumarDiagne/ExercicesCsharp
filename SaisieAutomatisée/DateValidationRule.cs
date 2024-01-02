using System.ComponentModel.DataAnnotations;

namespace SaisieAutomatisée
{

   public class DateValidationRule
   {
      public static ValidationResult? DateValide(DateTime date)
      {
         if (date.Ticks >= new DateTime(1900, 1, 1).Ticks || date.Ticks < DateTime.Now.Ticks)
            return ValidationResult.Success;
         else return new ValidationResult("cccccla date doit etre comprise entre le 01/01/1900 et la date du jour");
      }

   }
}