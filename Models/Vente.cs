using System;
using System.Collections.Generic;

namespace BidCardCoin.Models
{
    public class Vente
    {
        private string _idVente;
        private DateTime _dateDebut;
        private List<Produit> _listProduits;

        public Vente(string idVente, DateTime dateDebut, List<Produit> listProduits)
        {
            this._idVente = idVente;
            this._dateDebut = dateDebut;
            this._listProduits = listProduits;
        }
    }
}