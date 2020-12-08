using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Categorie
    {
        private string _idCategorie;
        private Categorie _categorie;
        private string _nomCategorie;
        private Dictionary<string, string> _dictionnaireProprietesOptionnelles;
        public Categorie(string idCategorie, Categorie categorie, string nomCategorie, Dictionary<string, string> dictionnaireProprietesOptionnelles)
        {
            this._idCategorie = idCategorie;
            this._categorie = categorie;
            this._nomCategorie = nomCategorie;
            this._dictionnaireProprietesOptionnelles = dictionnaireProprietesOptionnelles;
        }
    }
}