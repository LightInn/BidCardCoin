using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Lot
    {
        private string _idLot;
        private string _nomLot;
        private string _description;
        private List<Produit> _listeProduit;

        public Lot(string idLot, string nomLot, string description, List<Produit> listeProduit)
        {
            this._idLot = idLot;
            this._nomLot = nomLot;
            this._description = description;
            this._listeProduit = listeProduit;
        }
    }
}