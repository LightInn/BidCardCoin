namespace BidCardCoin.Models
{
    public class Stock
    {
        private string _idStock;
        private int _quantite;
        private Adresse _adresse;
        
        
        
        
        public Stock(string idStock, int quantite, Adresse adresse)
        {
            this._idStock = idStock;
            this._quantite = quantite;
            _adresse = adresse;
        }
    }
}