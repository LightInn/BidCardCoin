using System;
using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Vente
    {
        private string _idVente;
        private DateTime _dateDebut;
        private Adresse _adresse;
        private List<Lot> _listeLot;

        public Vente(string idVente, DateTime dateDebut, Adresse adresse, List<Lot> listeLot)
        {
            this._idVente = idVente;
            this._dateDebut = dateDebut;
            this._adresse = adresse;
            this._listeLot = listeLot;
        }
    }
}