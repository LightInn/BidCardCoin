using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class StockDAO
    {
        private string _idStock;
        private int _quantite;
        private string _adresseId;

        public StockDAO()
        {
        }

        public StockDAO(string idStock, int quantite, string adresseId)
        {
            this._idStock = idStock;
            this._quantite = quantite;
            this._adresseId = adresseId;
        }
    }
}
