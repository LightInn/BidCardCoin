namespace BidCardCoin.Models
{
    public class Stock
    {
        public Stock()
        {
        }

        public Stock(string idStock, Adresse adresse)
        {
            IdStock = idStock;
            AdresseStock = adresse;
        }

        public string IdStock { get; }
        public Adresse AdresseStock { get; set; }
    }
}