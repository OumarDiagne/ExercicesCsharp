namespace Services.UI
{

   public class ServiceFacture : IServiceFacture
   {
      #region Constantes et variables
      private static int _compteur;
      private const int DELAI_PAIEMENT = 30;
      public static readonly decimal TAUX_TVA = 0.2m;
      #endregion

      #region Propriétés 
      public int NumeroFacture { get; }
      public DateTime DateCreation { get; set; }
      public decimal MontantHT => Prestation?.PrixHT ?? 0;
      public decimal TVA => Prestation?.PrixHT * TAUX_TVA ?? 0;
      public decimal MontantTTC => TVA + MontantHT;
      public int DelaiPaiement { get; set; } = DELAI_PAIEMENT;
      public IClient? Client { get; set; }
      public IPrestation? Prestation { get; set; }

      public long Numero => NumeroFacture;



      #endregion

      #region Constructeurs

      public ServiceFacture()
      {

         NumeroFacture = ++_compteur;

      }
      #endregion

      #region Méthodes d'instances
      public string Editer()
      {

         return $""" 
        Facture n°{NumeroFacture} du {DateCreation:dd/MM/yy} 

        Emetteur :
        Société ABC
        3 avenue des champs Elysées - 75008 Paris
        Siren : 687 456 321

        {Client}

        {Prestation}

          Prix HT :    {MontantHT,11:C2}
              TVA :    {TVA,11:C2}
        Total TTC :    {MontantTTC,11:C2}
        ----------------------------
        """;
      }

      #endregion

      #region Methodes Privées
      #endregion

      #region Methodes Statiques
      #endregion
   }
}

