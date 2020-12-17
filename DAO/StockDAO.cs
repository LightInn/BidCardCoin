namespace bidCardCoin.DAO
{
    public class StockDAO
    {
        public StockDAO()
        {
        }

        public StockDAO(string idStock, string adresseId)

        {
            IdStock = idStock;
            AdresseId = adresseId;
        }

        public string IdStock { get; }
        public string AdresseId { get; }
    }
}