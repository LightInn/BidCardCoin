using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAL;
using bidCardCoin.DAO;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class CategorieORM
    {
        private static Dictionary<string, Categorie> _categoriesDictionary = new Dictionary<string, Categorie>();
        private static bool CategorieAlreadyInDictionary(string id)
        {
            return _categoriesDictionary.ContainsKey(id);
        }
        // todo - bré est en train de le faire normalement
        public static void Populate(List<Categorie> categories)
        {
            // todo
        }
        public static void Populate(Categorie categories)
        {
            // todo
        }

        public static Categorie GetCategorieById(string id, bool initializer = true)
        {
            // todo
            Categorie categorie = new Categorie();

            return categorie;
        }
    }
}
