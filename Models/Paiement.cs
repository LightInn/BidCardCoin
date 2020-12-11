namespace BidCardCoin.Models
{
    public class Paiement
    {
        public string IdPaiement { get; }
        public Lot LotPaiement { get; set; }
        public Utilisateur UtilisateurPaiement { get; set; }
        public string TypePaiement { get; }
        public bool ValidationPaiement { get; }

        public Paiement(){}
        public Paiement(string idPaiement, Utilisateur utilisateur, string typePaiement, bool validationPaiement, Lot lot)
        {
            this.IdPaiement = idPaiement;
            this.UtilisateurPaiement = utilisateur;
            this.TypePaiement = typePaiement;
            this.ValidationPaiement = validationPaiement;
            this.LotPaiement = lot;
        }
    }
}