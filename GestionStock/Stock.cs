namespace GestionStock
{
   public class Stock
   {
      public SortedList<DateTime, Mouvement>? _mouvements = new();
      #region Propriétés
      public int SeuilAlerte { get; set; }
      private int ValeurStock { get; set; }

      #endregion

      #region Methodes
      public void Ajouter(int quantite, DateTime date)
      {
         _mouvements!.Add(date, new Mouvement
         {
            Quantite = quantite,
            Date = date,
            Type = Type.Entree
         });

      }

      public (int, DateTime) GetEtatStock(DateTime date)
      {
         return (ValeurStock, date);

      }

      public void Retirer(int quantite, DateTime date)
      {
         if (DateTime.Now == date)
         {

            if (ValeurStock - quantite < 0)
            {
               throw new InvalidOperationException();
            }
            else if (ValeurStock - quantite < SeuilAlerte)
            {
               ValeurStock -= quantite;
               AlerteStockBas?.Invoke(null, ValeurStock);
            }
         }

      }
      public void RemettreAZero(DateTime date)
      {

         if (DateTime.Now == date)
            ValeurStock = 0;
      }



      #endregion
      #region Events
      public static event EventHandler<int>? AlerteStockBas;
      #endregion

   }

}
