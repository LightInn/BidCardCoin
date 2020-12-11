using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class LotORM
    {
        private static Dictionary<string, Lot> _lotsDictionary = new Dictionary<string, Lot>();
        private static bool LotAlreadyInDictionary(string id)
        {
            return _lotsDictionary.ContainsKey(id);
        }
        // todo -> liens vers des : produits
    }
}
