using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class StockDAO
    {
        public string IdStock { get; }
        public string AdresseId { get; }

        public StockDAO()
        {
        }

        public StockDAO()
        {
            
        }
        public StockDAO(string idStock, string adresseId)

        {
            this.IdStock = idStock;
            this.AdresseId = adresseId;
        }
    }
}
