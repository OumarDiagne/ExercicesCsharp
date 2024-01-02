using System.ComponentModel.DataAnnotations;

namespace SaisieAutomatisée
{
   public class Client : ValidationBase
   {
      #region champs privés
      private int _id;
      private string _nom = string.Empty;
      private string _prenom = string.Empty;
      private DateTime _dateNais;
      #endregion

      #region Propriétés

      [Required]
      [Display(Prompt = "Entrer un Id :")]
      [Range(1, 99999, ErrorMessage = "obligatoire et compris entre 1 et 99999")]
      public int Id
      {
         get => _id;
         set
         {
            ValidateProperty(value);
            _id = value;
            ;
         }
      }

      [Required]
      [Display(Prompt = "Entrer votre Nom :")]
      [StringLength(40, ErrorMessage = "obligatoire et 40 caractères maxi")]
      public string Nom
      {
         get => _nom;
         set
         {
            ValidateProperty(value);
            _nom = value;
            ;
         }
      }
      [Required]
      [Display(Prompt = "Entrer votre Prenom :")]
      [StringLength(40, ErrorMessage = "obligatoire et 40 caractères maxi")]
      public string prenom
      {
         get => _prenom;
         set
         {
            ValidateProperty(value);
            _prenom = value;
            ;
         }
      }
      [Required]
      [Display(Prompt = "Entrer votre date de naissance :")]
      [CustomValidation(typeof(DateValidationRule), nameof(DateValidationRule.DateValide))]
      public DateTime DateNais
      {
         get => _dateNais;
         set
         {


            ValidateProperty(value);
            _dateNais = value;
            ;
         }
      }
      #endregion
   }
}
