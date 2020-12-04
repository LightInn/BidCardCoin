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

        public Estimation(string idEstimation, Produit produit, Commissaire commissaire, DateTime dateEstimation, double prixEstimation)
        {
            this._idEstimation = idEstimation;
            this._produit = produit;
            this._commissaire = commissaire;
            this._dateEstimation = dateEstimation;
            this._prixEstimation = prixEstimation;
        }
    }
}