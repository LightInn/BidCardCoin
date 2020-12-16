namespace bidCardCoin.DAO
{
    public class PaiementDAO
    {
        public PaiementDAO()
        {
        }

        public PaiementDAO(string idPaiement, string lotId, string utilisateurId, string typePaiement,
            bool validationPaiement)
        {
            IdPaiement = idPaiement;
            LotId = lotId;
            UtilisateurId = utilisateurId;
            TypePaiement = typePaiement;
            ValidationPaiement = validationPaiement;
        }

        public string IdPaiement { get; }
        public string LotId { get; }
        public string UtilisateurId { get; }
        public string TypePaiement { get; }
        public bool ValidationPaiement { get; }
    }
}