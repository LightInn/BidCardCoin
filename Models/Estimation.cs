using System;

namespace BidCardCoin.Models
{
    public class Estimation
    {
        public string IdEstimation { get; }
        public Produit ProduitEstimation { get; set; }
        public Commissaire CommissaireEstimation { get; set; }
        public DateTime DateEstimation { get; }
        public double PrixEstimation { get; }

        public Estimation()
        {
            
        }
        public Estimation(string idEstimation, Produit produit, Commissaire commissaire, DateTime dateEstimation, double prixEstimation)
        {
            this.IdEstimation = idEstimation;
            this.ProduitEstimation = produit;
            this.CommissaireEstimation = commissaire;
            this.DateEstimation = dateEstimation;
            this.PrixEstimation = prixEstimation;
        }
    }
}