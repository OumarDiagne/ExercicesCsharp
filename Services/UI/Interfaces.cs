using System.Collections.ObjectModel;
using static Services.UI.Prestations;

namespace Services.UI
{
   public interface IClient
   {
      public int Id { get; }
      public string Adresse { get; set; }
      public string NomComplet { get; }
   }

   public interface IServiceFacture
   {
      public long Numero { get; }
      public DateTime DateCreation { get; set; }
      public IClient? Client { get; set; }
      public IPrestation? Prestation { get; set; }

      public string Editer();
   }
   public interface IPrestation
   {
      public long IdClient { get; set; }
      public DateTime DateDebut { get; }
      public string Intitule { get; set; }
      public decimal PrixHT { get; set; }
   }

   public interface IPrestationLongTerme : IPrestation
   {
      public ReadOnlyCollection<Etape> Etapes { get; }
      public void AjouterEtape(DateTime dateFin, float avancement, string libelle);
   }
}
