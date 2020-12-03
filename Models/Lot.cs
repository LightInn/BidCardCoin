namespace BidCardCoin.Models
{
    public class Lot
    {
        private string _idLot;
        private string _nomLot;
        private string _description;

        public Lot(string idLot, string nomLot, string description)
        {
            this._idLot = idLot;
            this._nomLot = nomLot;
            this._description = description;
        }
    }
}