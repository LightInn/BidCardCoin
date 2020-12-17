using System;

namespace bidCardCoin.DAO
{
    public class OrdreAchatDAO
    {
        public OrdreAchatDAO()
        {
        }

        public OrdreAchatDAO(string idOrdreAchat, string utilisateurId, string lotId, bool informatiser,
            double montantMax, DateTime date)
        {
            IdOrdreAchat = idOrdreAchat;
            UtilisateurId = utilisateurId;
            LotId = lotId;
            Informatiser = informatiser;
            MontantMax = montantMax;
            Date = date;
        }

        public string IdOrdreAchat { get; }
        public string UtilisateurId { get; }
        public string LotId { get; }
        public bool Informatiser { get; }
        public double MontantMax { get; }
        public DateTime Date { get; }
    }
}