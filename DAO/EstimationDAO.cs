using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class EstimationDAO
    {
        private string _idEstimation;
        private string _produitId;
        private string _commissaireId;
        // todo DateTime ou string ? objet dans dao ou on vise la transformation en objet pour orm ?
        // private DateTime dateEstimation;
        private string _dateEstimation;
        private double _prixEstimation;

        public EstimationDAO(string idEstimation, string produitId, string commissaireId, string dateEstimation, double prixEstimation)
        {
            this._idEstimation = idEstimation;
            this._produitId = produitId;
            this._commissaireId = commissaireId;
            this._dateEstimation = dateEstimation;
            this._prixEstimation = prixEstimation;
        }
    }
}
