using System;

namespace bidCardCoin.DAO
{
    public class EnchereDAO
    {
        // soit l'ordre d'achat, soit l'utilisateur mais pas les deux


        public EnchereDAO()
        {
        }


        // on cree une enchere 
        public EnchereDAO(string idEnchere, double prixProposer, bool estAdjuger, DateTime dateHeureVente, string lotId,
            string commissaireId, string ordreAchatId, string utilisateurId)
        {
            IdEnchere = idEnchere;
            PrixProposer = prixProposer;
            EstAdjuger = estAdjuger;
            DateHeureVente = dateHeureVente;
            LotId = lotId;
            CommissaireId = commissaireId;
            OrdreAchatId = ordreAchatId;
            UtilisateurId = utilisateurId;
        }

        public string IdEnchere { get; set; }

        public double PrixProposer { get; set; }

        public bool EstAdjuger { get; set; }

        public DateTime DateHeureVente { get; set; }

        public string LotId { get; set; }

        public string CommissaireId { get; set; }

        public string OrdreAchatId { get; set; }

        public string UtilisateurId { get; set; }
    }
}