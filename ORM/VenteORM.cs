using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class VenteORM
    {
        private static Dictionary<string, Vente> _ventesDictionary = new Dictionary<string, Vente>();
        private static bool VenteAlreadyInDictionary(string id)
        {
            return _ventesDictionary.ContainsKey(id);
        }
        // todo -> liens vers des : Lot 
        // todo -> liens vers une : adresse 
    }
}
