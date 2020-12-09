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
        private string _adresseId;

        public StockDAO(string idStock, string adresseId)
        {
            this._idStock = idStock;
            this._adresseId = adresseId;
        }
    }
}
