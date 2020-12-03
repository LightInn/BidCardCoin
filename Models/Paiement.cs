namespace BidCardCoin.Models
{
    public class Paiement
    {
        private Lot _lot;
        private Utilisateur _utilisateur;
        private string _typePaiement;
        private bool _validationPaiement;

        public Paiement(Utilisateur utilisateur, string typePaiement, bool validationPaiement, Lot lot)
        {
            this._utilisateur = utilisateur;
            this._typePaiement = typePaiement;
            this._validationPaiement = validationPaiement;
            this._lot = lot;
        }
    }
}