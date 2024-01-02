namespace MenuActions
{
   internal class Program
   {
      static void Main(string[] args)
      {
         List<(string libellé, Action action)> menu = new()
         {
         ("Quittez l'appli",() =>Environment.Exit(0)),
         ("Action 1 ",Actions.Action1),
         ("Action 2 ",Actions.Action2),

         };
      }
   }
}