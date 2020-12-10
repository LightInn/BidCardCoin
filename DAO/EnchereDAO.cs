using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class EnchereDAO
    {
        public string IdEnchere
        {
            get => _idEnchere;
            set => _idEnchere = value;
        }

        public double PrixProposer
        {
            get => _prixProposer;
            set => _prixProposer = value;
        }

        public bool EstAdjuger
        {
            get => _estAdjuger;
            set => _estAdjuger = value;
        }

        public DateTime DateHeureVente
        {
            get => _dateHeureVente;
            set => _dateHeureVente = value;
        }

        public string LotId
        {
            get => _lotId;
            set => _lotId = value;
        }

        public string CommissaireId
        {
            get => _commissaireId;
            set => _commissaireId = value;
        }

        public string OrdreAchatId
        {
            get => _ordreAchatId;
            set => _ordreAchatId = value;
        }

        public string UtilisateurId
        {
            get => _utilisateurId;
            set => _utilisateurId = value;
        }

        private string _idEnchere;
        private double _prixProposer;
        private bool _estAdjuger;
        private DateTime _dateHeureVente;
        private string _lotId;
        private string _commissaireId;
        
        // soit l'ordre d'achat, soit l'utilisateur mais pas les deux
        private string _ordreAchatId;
        private string _utilisateurId;

        

        public EnchereDAO()
        {
        }
        
        
        // on cree une enchere 
        public EnchereDAO(string idEnchere, double prixProposer, bool estAdjuger, DateTime dateHeureVente, string lotId, string commissaireId, string ordreAchatId,  string utilisateurId)
        {
            _idEnchere = idEnchere;
            _prixProposer = prixProposer;
            _estAdjuger = estAdjuger;
            _dateHeureVente = dateHeureVente;
            _lotId = lotId;
            _commissaireId = commissaireId;
            _ordreAchatId = ordreAchatId;
            _utilisateurId = utilisateurId;
        }
        
        

    }
}
