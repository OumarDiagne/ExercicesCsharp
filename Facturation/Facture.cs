namespace Facturation
{
   public class Facture
   {
      #region Constantes et variables
      private static int _compteur;
      private const int DELAI_PAIEMENT = 30;
      public static readonly decimal TAUX_TVA = 0.2m;
      #endregion

      #region Propriétés 
      public int NumeroFacture { get; }
      public DateTime DateCreation { get; set; }
      public decimal MontantHT => Prestation.PrixHT;
      public decimal TVA => Prestation.PrixHT * TAUX_TVA;
      public decimal MontantTTC => TVA + MontantHT;
      public int DelaiPaiement { get; set; } = DELAI_PAIEMENT;
      public Client Client { get; set; }
      public Prestation Prestation { get; set; }

      #endregion

      #region Constructeurs

      public Facture(Client client, Prestation prestation, DateTime dateCreation)
      {
         NumeroFacture = ++_compteur;
         DateCreation = dateCreation;
         Client = client;
         Prestation = prestation;
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
