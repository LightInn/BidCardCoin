using System;

namespace BidCardCoin.Models
{
    public class OrdreAchat
    {
        public string IdOrdreAchat { get; }
        public Utilisateur UtilisateurOrdreAchat { get; set; }
        public Lot LotOrdreAchat { get; set; }
        public bool Autobot { get; }
        public double MontantMax { get; }
        public DateTime DateCreation { get; }

        public OrdreAchat()
        {
            
        }
        public OrdreAchat(string idOrdreAchat, Utilisateur utilisateur, Lot lot, bool autobot, double montantMax, DateTime dateCreation)
        {
            this.IdOrdreAchat = idOrdreAchat;
            this.UtilisateurOrdreAchat = utilisateur;
            this.LotOrdreAchat = lot;
            this.Autobot = autobot;
            this.MontantMax = montantMax;
            this.DateCreation = dateCreation;
        }
    }
}