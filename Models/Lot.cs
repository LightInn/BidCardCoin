using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Lot
    {
        public Lot()
        {
        }

        public Lot(string idLot, string nomLot, string description, List<Produit> listeProduit)
        {
            IdLot = idLot;
            NomLot = nomLot;
            Description = description;
            ListeProduit = listeProduit;
        }

        public string IdLot { get; set; }
        public string NomLot { get; set; }
        public string Description { get; set; }
        public List<Produit> ListeProduit { get; set; }
    }
}