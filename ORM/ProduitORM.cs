using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class ProduitORM
    {
        private static Dictionary<string, Produit> _produitsDictionary = new Dictionary<string, Produit>();
        private static bool ProduitAlreadyInDictionary(string id)
        {
            return _produitsDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Lot // Utilisateur // Stock // Enchere
    }
}
