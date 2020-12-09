using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class AdresseDAO
    {

        private string _idAdresse;
        private string _pays;
        private string _region;
        private string _ville;
        private string _codePostal;

        public AdresseDAO()
        {
        }

        public AdresseDAO(string idAdresse, string pays, string region, string ville, string codePostal)
        {
            this._idAdresse = idAdresse;
            this._pays = pays;
            this._region = region;
            this._ville = ville;
            this._codePostal = codePostal;
        }

    }
}
