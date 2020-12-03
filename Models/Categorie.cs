namespace BidCardCoin.Models
{
    public class Categorie
    {
        private string _idCategorie;
        private Categorie _categorie;
        private string _nomCategorie;

        public Categorie(string idCategorie, Categorie categorie, string nomCategorie)
        {
            this._idCategorie = idCategorie;
            _categorie = categorie;
            this._nomCategorie = nomCategorie;
        }
    }
}