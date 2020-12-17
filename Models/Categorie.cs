using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Categorie
    {
        // todo propriétés optionnelles ?
        //public Dictionary<string, string> DictionnaireProprietesOptionnelles { get; set; }

        public Categorie()
        {
        }

        public Categorie(string idCategorie, Categorie categorie, string nomCategorie)
        {
            IdCategorie = idCategorie;
            CategorieParent = categorie;
            NomCategorie = nomCategorie;
            //this.DictionnaireProprietesOptionnelles = dictionnaireProprietesOptionnelles;
        }

        public static Dictionary<string, Categorie> CategoriesCollection { get; }

        public string IdCategorie { get; set; }
        public Categorie CategorieParent { get; set; }
        public string NomCategorie { get; set; }
    }
}