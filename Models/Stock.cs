namespace BidCardCoin.Models
{
    public class Stock
    {
        private string _idStock;
        private Adresse _adresse;

        public Stock(string idStock, Adresse adresse)
        {
            this._idStock = idStock;
            this._adresse = adresse;
        }
    }
}