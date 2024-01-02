namespace GestionStock
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello, World!");

         Stock stock = new Stock();
         stock.SeuilAlerte = 50;
      }
   }
}