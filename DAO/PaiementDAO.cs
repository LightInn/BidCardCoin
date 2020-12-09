using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class PaiementDAO
    {
        private string _idPaiement;
        private string _lotId;
        private string _utilisateurId;
        private string _typePaiement;
        private bool _validationPaiement;

        public PaiementDAO()
        {
        }

        public PaiementDAO(string idPaiement, string lotId, string utilisateurId, string typePaiement, bool validationPaiement)
        {
            _idPaiement = idPaiement;
            _lotId = lotId;
            _utilisateurId = utilisateurId;
            _typePaiement = typePaiement;
            _validationPaiement = validationPaiement;
        }
    }
}
