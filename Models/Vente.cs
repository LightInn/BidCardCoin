using System;

namespace BidCardCoin.Models
{
    public class Vente
    {
        private string _idVente;
        private DateTime _dateDebut;

        public Vente(string idVente, DateTime dateDebut)
        {
            this._idVente = idVente;
            this._dateDebut = dateDebut;
        }
    }
}