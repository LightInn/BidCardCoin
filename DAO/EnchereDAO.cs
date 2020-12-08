using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class EnchereDAO
    {
        private string _idEnchere;
        private double _prixProposer;
        private bool _estAdjuger;
        // todo DateTime ou string ? objet dans dao ou on vise la transformation en objet pour orm ?
        //private DateTime dateHeureVente;
        private string _dateHeureVente;
        private string _lotId;
        private string _commissaireId;
        
        // soit l'ordre d'achat, soit l'utilisateur mais pas les deux
        private string _ordreAchatId;
        private string _utilisateurId;

        // on cree une enchere avec l'ordre d'achat
        public EnchereDAO(string idEnchere, double prixProposer, bool estAdjuger, string dateHeureVente, string lotId, string commissaireId, string ordreAchatId)
        {
            _idEnchere = idEnchere;
            _prixProposer = prixProposer;
            _estAdjuger = estAdjuger;
            _dateHeureVente = dateHeureVente;
            _lotId = lotId;
            _commissaireId = commissaireId;
            _ordreAchatId = ordreAchatId;
        }


        // on cree une enchere avec l'utilisateur
        public EnchereDAO(string idEnchere,bool estAdjuger, double prixProposer, string dateHeureVente, string lotId, string commissaireId, string utilisateurId)
        {
            _idEnchere = idEnchere;
            _prixProposer = prixProposer;
            _estAdjuger = estAdjuger;
            _dateHeureVente = dateHeureVente;
            _lotId = lotId;
            _commissaireId = commissaireId;
            _utilisateurId = utilisateurId;
        }

    }
}
