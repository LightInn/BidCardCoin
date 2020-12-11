using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class OrdreAchatORM
    {
        private static Dictionary<string, OrdreAchat> _ordreAchatsDictionary = new Dictionary<string, OrdreAchat>();
        private static bool OrdreAchatAlreadyInDictionary(string id)
        {
            return _ordreAchatsDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Utilisateur / Lot
    }
}
