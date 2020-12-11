namespace BidCardCoin.Models
{
    public class Stock
    {
        public string IdStock { get; }
        public Adresse AdresseStock { get; set; }

        public Stock(){}
        public Stock(string idStock, Adresse adresse)
        {
            this.IdStock = idStock;
            this.AdresseStock = adresse;
        }
    }
}