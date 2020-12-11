using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class StockORM
    {
        private static Dictionary<string, Stock> _stocksDictionary = new Dictionary<string, Stock>();
        private static bool StockAlreadyInDictionary(string id)
        {
            return _stocksDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Adresse
    }
}
