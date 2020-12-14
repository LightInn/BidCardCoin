using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Lot
    {
        public string IdLot { get; set; }
        public string NomLot { get; set; }
        public string Description { get; set; }
        public List<Produit> ListeProduit { get; set; }

        public Lot()
        {
            
        }
        public Lot(string idLot, string nomLot, string description, List<Produit> listeProduit)
        {
            this.IdLot = idLot;
            this.NomLot = nomLot;
            this.Description = description;
            this.ListeProduit = listeProduit;
        }
    }
}