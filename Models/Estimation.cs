using System;

namespace BidCardCoin.Models
{
    public class Estimation
    {
        public Estimation()
        {
        }

        public Estimation(string idEstimation, Produit produit, Commissaire commissaire, DateTime dateEstimation,
            double prixEstimation)
        {
            IdEstimation = idEstimation;
            ProduitEstimation = produit;
            CommissaireEstimation = commissaire;
            DateEstimation = dateEstimation;
            PrixEstimation = prixEstimation;
        }

        public string IdEstimation { get; }
        public Produit ProduitEstimation { get; set; }
        public Commissaire CommissaireEstimation { get; set; }
        public DateTime DateEstimation { get; }
        public double PrixEstimation { get; }
    }
}