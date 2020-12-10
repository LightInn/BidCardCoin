using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class EstimationDAO
    {
        public string IdEstimation { get; }
        public string ProduitId { get; }

        public string CommissaireId { get; }

        // todo DateTime ou string ? objet dans dao ou on vise la transformation en objet pour orm ?
        // private DateTime dateEstimation;
        public DateTime DateEstimation { get; }
        public double PrixEstimation { get; }

        public EstimationDAO()
        {
            
        }

        public EstimationDAO(string idEstimation, string produitId, string commissaireId, DateTime dateEstimation, double prixEstimation)
        {
            this.IdEstimation = idEstimation;
            this.ProduitId = produitId;
            this.CommissaireId = commissaireId;
            this.DateEstimation = dateEstimation;
            this.PrixEstimation = prixEstimation;
        }
    }
}
