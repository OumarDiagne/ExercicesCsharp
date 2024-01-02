namespace ClassesEtendues
{
   internal class Program
   {
      static void Main(string[] args)
      {
         DateTime dto = new DateTime(2000, 10, 19);

         Console.WriteLine($"Date de départ: {dto:D}");
         Console.WriteLine($"Premier jour du mois : {dto.GetBeginningOfmonth():D}");
         Console.WriteLine($"Dernier jour du mois : {dto.GetEndOfmonth():D}");
         Console.WriteLine($"Nombre d'années entières entre la date de départ et le {DateTime.Today:d}: {dto.GetAge():D}");

         var dt1 = dto.AddDays(-365 * 8).AddHours(-1).AddDays(1);
         Console.WriteLine($"Nombre d'années entières entre la date de départ {dt1:f} et le {DateTime.Now:f}: {dt1.GetAge():D}");
      }
   }


   public static class DatetimeExtension
   {
      public static DateTime GetBeginningOfmonth(this DateTime date)
      {

         return new DateTime(date.Year, date.Month, 1);
      }


      public static DateTime GetEndOfmonth(this DateTime date)
      {
         return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
      }


      public static long GetAge(this DateTime date)
      {

         var dateNowticks = DateTime.Now.Ticks;
         var dateticks = date.Ticks;
         var ticksparAnnee = new DateTime(2022, 1, 1, 0, 0, 0).Ticks - new DateTime(2021, 1, 1, 0, 0, 0).Ticks;


         return (dateNowticks - dateticks) / ticksparAnnee;
      }
   }
}