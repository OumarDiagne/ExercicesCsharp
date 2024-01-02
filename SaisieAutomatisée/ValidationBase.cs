using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SaisieAutomatisée
{
   public class ValidationBase
   {
      /// <summary>
      /// Vérifie la validité d'une valeur de proppriété à partir des attributs qui la décorent
      /// </summary>
      /// <param name="value">Valeur à valider</param>
      /// <param name="propertyName">Nom de la propriété si pas déterminé automatiquement</param>
      /// <exception cref="ValidationException">valeur de propriété non valide</exception>
      public void ValidateProperty(object value, [CallerMemberName] string? propertyName = null)
      {
         ValidationContext context = new(this);
         context.MemberName = propertyName;
         Validator.ValidateProperty(value, context);
         //exception levée si value pas valide.
      }
   }
}
