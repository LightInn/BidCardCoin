using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class CategorieDAO
    {
        private string _idCategorie;
        private string _categorieId;
        private string _nomCategorie;

        public CategorieDAO(string idCategorie, string nomCategorie)
        {
            this._idCategorie = idCategorie;
            this._nomCategorie = nomCategorie;
        }
        public CategorieDAO(string idCategorie, string categorieId, string nomCategorie)
        {
            this._idCategorie = idCategorie;
            this._categorieId = categorieId;
            this._nomCategorie = nomCategorie;
        }
    }
}
