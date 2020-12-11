using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class EnchereORM
    {
        private static Dictionary<string, Enchere> _encheresDictionary = new Dictionary<string, Enchere>();
        private static bool EnchereAlreadyInDictionary(string id)
        {
            return _encheresDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Commissaire // Lot // Ordre Achat OU Utilisateur
    }
}
