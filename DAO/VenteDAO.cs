using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class VenteDAO
    {
        private string _idVente;
        private string _produitId;
        private string _adresseId;
        private string _dateDebut;

        public VenteDAO(string idVente, string produitId, string adresseId, string dateDebut)
        {
            this._idVente = idVente;
            this._produitId = produitId;
            this._adresseId = adresseId;
            this._dateDebut = dateDebut;
        }
    }
}
