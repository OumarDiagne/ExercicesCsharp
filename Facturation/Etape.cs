namespace Facturation
{
   public class Etape
   {

      #region Propriétés publiques
      public string Libelle { get; set; } = string.Empty;
      public float Avancement { get; set; }
      public DateTime DateDebut { get; set; }
      public DateTime DateFin { get; set; }
      #endregion

      #region Constructeur
      public Etape(DateTime dateDébut, DateTime dateFin, float avancement, string libellé)
      {
         DateDebut = dateDébut;
         DateFin = dateFin;
         Avancement = avancement;
         Libelle = libellé;
      }

      public override string ToString()
      {
         return $"""
      Prestation : {Libelle}
      Période du {DateDebut:d} au {DateFin:d}
      Avancement : {Avancement:#%}
      """;
      }
      #endregion


   }
}
