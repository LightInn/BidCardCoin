using System.Collections.Generic;

namespace bidCardCoin.DAO
{
    public class CategorieDAO
    {
        public CategorieDAO()
        {
        }

        public CategorieDAO(string idCategorie, string categorieId, string nomCategorie)
        {
            IdCategorie = idCategorie;
            CategorieId = categorieId;
            NomCategorie = nomCategorie;
        }

        public string IdCategorie { get; }
        public string CategorieId { get; }
        public string NomCategorie { get; }
        public IEnumerable<string> ListeCategorieId { get; set; }
        public IEnumerable<string> ListeProduitId { get; set; }
    }
}