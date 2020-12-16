using System.Collections.Generic;
using bidCardCoin.DAL;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class EstimationORM
    {
        private static readonly Dictionary<string, Estimation> _estimationsDictionary =
            new Dictionary<string, Estimation>();

        private static bool EstimationAlreadyInDictionary(string id)
        {
            return _estimationsDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Commissaire // Estimation

        public static void Populate(List<Estimation> estimations)
        {
            // liste des estimations qui on beusoin de se faire peupler (leurs liste utilisateurs)

            foreach (var estimation in estimations)
            {
                if (!EstimationAlreadyInDictionary(estimation.IdEstimation)) GetEstimationById(estimation.IdEstimation);

                estimation.CommissaireEstimation =
                    _estimationsDictionary[estimation.IdEstimation].CommissaireEstimation;
                estimation.ProduitEstimation = _estimationsDictionary[estimation.IdEstimation].ProduitEstimation;
            }
        }

        public static void Populate(Estimation estimation)
        {
            // liste des estimations qui on beusoin de se faire peupler (leurs liste utilisateurs)

            if (!EstimationAlreadyInDictionary(estimation.IdEstimation)) GetEstimationById(estimation.IdEstimation);

            estimation.CommissaireEstimation = _estimationsDictionary[estimation.IdEstimation].CommissaireEstimation;
            estimation.ProduitEstimation = _estimationsDictionary[estimation.IdEstimation].ProduitEstimation;
        }

        public static Estimation GetEstimationById(string id, bool initializer = true)
        {
            var edao = EstimationDAL.SelectEstimationById(id);
            var commissaireEstimation = new Commissaire();
            var produitEstimation = new Produit();

            if (initializer)
            {
                commissaireEstimation =
                    CommissaireORM.GetCommissaireById(
                        CommissaireDAL.SelectCommissaireById(edao.CommissaireId).IdCommissaire, false);
                produitEstimation =
                    ProduitORM.GetProduitById(ProduitDAL.SelectProduitById(edao.ProduitId).IdProduit, false);
            }


            var estimation = new Estimation(edao.CommissaireId, produitEstimation, commissaireEstimation,
                edao.DateEstimation, edao.PrixEstimation);

            if (initializer)
            {
                _estimationsDictionary[estimation.IdEstimation] = estimation;

                CommissaireORM.Populate(new List<Commissaire>(new[]
                {
                    estimation.CommissaireEstimation
                }));
                ProduitORM.Populate(estimation.ProduitEstimation);
            }

            return estimation;
        }

        public static List<Estimation> GetAllEstimation()
        {
            var ledao = EstimationDAL.SelectAllEstimation();
            var estimations = new List<Estimation>();

            foreach (var edao in ledao) estimations.Add(GetEstimationById(edao.IdEstimation));

            return estimations;
        }
    }
}