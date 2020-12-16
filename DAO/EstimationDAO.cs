using System;

namespace bidCardCoin.DAO
{
    public class EstimationDAO
    {
        public EstimationDAO()
        {
        }

        public EstimationDAO(string idEstimation, string produitId, string commissaireId, DateTime dateEstimation,
            double prixEstimation)
        {
            IdEstimation = idEstimation;
            ProduitId = produitId;
            CommissaireId = commissaireId;
            DateEstimation = dateEstimation;
            PrixEstimation = prixEstimation;
        }

        public string IdEstimation { get; }
        public string ProduitId { get; }

        public string CommissaireId { get; }

        // todo DateTime ou string ? objet dans dao ou on vise la transformation en objet pour orm ?
        // private DateTime dateEstimation;
        public DateTime DateEstimation { get; }
        public double PrixEstimation { get; }
    }
}