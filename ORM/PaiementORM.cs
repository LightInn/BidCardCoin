using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class PaiementORM
    {
        private static Dictionary<string, Paiement> _paiementsDictionary = new Dictionary<string, Paiement>();
        private static bool PaiementAlreadyInDictionary(string id)
        {
            return _paiementsDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Utilisateur // Lot
    }
}
