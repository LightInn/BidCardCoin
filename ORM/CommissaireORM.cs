using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class CommissaireORM
    {
        private static Dictionary<string, Commissaire> _commissairesDictionary = new Dictionary<string, Commissaire>();
        private static bool CommissaireAlreadyInDictionary(string id)
        {
            return _commissairesDictionary.ContainsKey(id);
        }
        // todo - bré est en train de le faire normalement
    }
}
