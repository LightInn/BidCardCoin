using System;

namespace BidCardCoin.Models
{
    public class Estimation
    {
        private string _idEstimation;
        private Produit _produit;
        private Commissaire _commissaire;
        private DateTime _dateEstimation;
        private double _prixEstimation;

        public Estimation(Commissaire commissaire, DateTime dateEstimation, double prixEstimation, string idEstimation,
            Produit produit)
        {
            _commissaire = commissaire;
            this._dateEstimation = dateEstimation;
            this._prixEstimation = prixEstimation;
            this._idEstimation = idEstimation;
            _produit = produit;
        }
    }
}