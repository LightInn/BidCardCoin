using System;

namespace BidCardCoin.Models
{
    public class Enchere
    {
        public string IdEnchere { get; }
        public double PrixProposer { get; }
        public bool IsAdjuger { get; }
        public DateTime DateHeureVente { get; }
        public OrdreAchat OrdreAchatEnchere { get; set; }
        public Lot LotEnchere { get; set; }
        public Commissaire CommissaireEnchere { get; set; }
        public Utilisateur UtilisateurEnchere { get; set; }

        public Enchere()
        {
            
        }
        public Enchere(string idEnchere, double prixProposer, bool isAdjuger, DateTime dateHeureVente,
            OrdreAchat ordreOrdreAchatEnchere, Lot lot, Commissaire commissaire, Utilisateur utilisateur)
        {
            this.IdEnchere = idEnchere;
            this.PrixProposer = prixProposer;
            this.IsAdjuger = isAdjuger;
            this.DateHeureVente = dateHeureVente;
            this.OrdreAchatEnchere = ordreOrdreAchatEnchere;
            this.LotEnchere = lot;
            this.CommissaireEnchere = commissaire;
            this.UtilisateurEnchere = utilisateur;
        }
        
    }
}