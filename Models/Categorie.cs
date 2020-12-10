using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BidCardCoin.Models
{
    public class Categorie
    {
        public static Dictionary<string, Categorie> CategoriesCollection { get; }

        public string IdCategorie { get; set; }
        public Categorie CategorieParent { get; set; }
        public string NomCategorie { get; set; }
        // todo propriétés optionnelles ?
        //public Dictionary<string, string> DictionnaireProprietesOptionnelles { get; set; }

        public Categorie()
        {
            
        }
        public Categorie(string idCategorie, Categorie categorie, string nomCategorie)
        {
            this.IdCategorie = idCategorie;
            this.CategorieParent = categorie;
            this.NomCategorie = nomCategorie;
            //this.DictionnaireProprietesOptionnelles = dictionnaireProprietesOptionnelles;
        }
    }
}