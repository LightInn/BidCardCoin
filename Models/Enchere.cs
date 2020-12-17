using System;

namespace BidCardCoin.Models
{
    public class Enchere
    {
        public Enchere()
        {
        }

        public Enchere(string idEnchere, double prixProposer, bool isAdjuger, DateTime dateHeureVente,
            OrdreAchat ordreOrdreAchatEnchere, Lot lot, Commissaire commissaire, Utilisateur utilisateur)
        {
            IdEnchere = idEnchere;
            PrixProposer = prixProposer;
            IsAdjuger = isAdjuger;
            DateHeureVente = dateHeureVente;
            OrdreAchatEnchere = ordreOrdreAchatEnchere;
            LotEnchere = lot;
            CommissaireEnchere = commissaire;
            UtilisateurEnchere = utilisateur;
        }

        public string IdEnchere { get; set; }
        public double PrixProposer { get; set; }
        public bool IsAdjuger { get; set; }
        public DateTime DateHeureVente { get; set; }
        public OrdreAchat OrdreAchatEnchere { get; set; }
        public Lot LotEnchere { get; set; }
        public Commissaire CommissaireEnchere { get; set; }
        public Utilisateur UtilisateurEnchere { get; set; }
    }
}