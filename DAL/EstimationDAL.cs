using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class EstimationDAL
    {
        // SELECT

        public static EstimationDAO SelectEstimationById(string id)
        {
            // Selectionné l'Estimation a partir de l'id
            return new EstimationDAO();
        }


        public static List<EstimationDAO> SelectAllEstimation()
        {
            // Selectionné tout les Estimation dans la base de donnée
            return new List<EstimationDAO>();
        }


// INSERT

        public static void InsertNewEstimation(EstimationDAO Estimation)
        {
            // Inserer Estimation dans la bdd
        }

// UPDATE

        public static void UpdateEstimation(EstimationDAO Estimation)
        {
            // Mettre a jour Estimation dans la bdd
        }

// DELETE

        public static void DeleteEstimation(string EstimationId)
        {
            // Supprimer Estimation dans la bdd
        }
    }
}
