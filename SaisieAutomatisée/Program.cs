namespace SaisieAutomatisée
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Client client = new Client();
         //client.SaisirValeursClientForm();
         Input.SaisirValeursProprietés(client);
      }
   }
}