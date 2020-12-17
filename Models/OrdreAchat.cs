using System;

namespace BidCardCoin.Models
{
    public class OrdreAchat
    {
        public OrdreAchat()
        {
        }

        public OrdreAchat(string idOrdreAchat, Utilisateur utilisateur, Lot lot, bool autobot, double montantMax,
            DateTime dateCreation)
        {
            IdOrdreAchat = idOrdreAchat;
            UtilisateurOrdreAchat = utilisateur;
            LotOrdreAchat = lot;
            Autobot = autobot;
            MontantMax = montantMax;
            DateCreation = dateCreation;
        }

        public string IdOrdreAchat { get; }
        public Utilisateur UtilisateurOrdreAchat { get; set; }
        public Lot LotOrdreAchat { get; set; }
        public bool Autobot { get; }
        public double MontantMax { get; }
        public DateTime DateCreation { get; }
    }
}