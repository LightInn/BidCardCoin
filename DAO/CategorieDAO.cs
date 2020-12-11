using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class CategorieDAO
    {
        public string IdCategorie { get; }
        public string CategorieId { get; }
        public string NomCategorie { get; }
        public IEnumerable<string> ListeCategorieId { get; set; }
        public IEnumerable<string> ListeProduitId { get; set; }

        public CategorieDAO()
        {
            
        }
        public CategorieDAO(string idCategorie, string nomCategorie)
        {
            this.IdCategorie = idCategorie;
            this.NomCategorie = nomCategorie;
        }
        public CategorieDAO(string idCategorie, string categorieId, string nomCategorie)
        {
            this.IdCategorie = idCategorie;
            this.CategorieId = categorieId;
            this.NomCategorie = nomCategorie;
        }
    }
}
