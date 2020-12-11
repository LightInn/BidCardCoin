using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class EstimationORM
    {
        private static Dictionary<string, Estimation> _estimationsDictionary = new Dictionary<string, Estimation>();
        private static bool EstimationAlreadyInDictionary(string id)
        {
            return _estimationsDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Commissaire // Produit
    }
}
