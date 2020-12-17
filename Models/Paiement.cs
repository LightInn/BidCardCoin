namespace BidCardCoin.Models
{
    public class Paiement
    {
        public Paiement()
        {
        }

        public Paiement(string idPaiement, Utilisateur utilisateur, string typePaiement, bool validationPaiement,
            Lot lot)
        {
            IdPaiement = idPaiement;
            UtilisateurPaiement = utilisateur;
            TypePaiement = typePaiement;
            ValidationPaiement = validationPaiement;
            LotPaiement = lot;
        }

        public string IdPaiement { get; }
        public Lot LotPaiement { get; set; }
        public Utilisateur UtilisateurPaiement { get; set; }
        public string TypePaiement { get; }
        public bool ValidationPaiement { get; }
    }
}