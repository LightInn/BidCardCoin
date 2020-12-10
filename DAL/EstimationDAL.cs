using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;
using Google.Protobuf.WellKnownTypes;
using Npgsql;

namespace bidCardCoin.DAL
{
    public static class EstimationDAL
    {
        // SELECT
        public static EstimationDAO SelectEstimationById(string id)
        {
            EstimationDAO estimationDao = new EstimationDAO();
            // Selectionne la estimation a partir de l'id
            var query =
                "SELECT * FROM public.estimation a where a.\"idEstimation\"= :idEstimationParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idEstimationParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idEstimation = (string) reader["idEstimation"];
                var produitId = (string) reader["produitId"];
                var commissaireId = (string) reader["commissaireId"];
                var dateEstimation = (DateTime) reader["dateEstimation"];
                var prixEstimation = (double) reader["prixEstimation"];
                return new EstimationDAO(idEstimation, produitId, commissaireId,dateEstimation,prixEstimation);
            }

            return new EstimationDAO();
        }

        public static List<EstimationDAO> SelectAllEstimation()
        {
            // Selectionné tout les estimation dans la base de donnée
            List<EstimationDAO> liste = new List<EstimationDAO>();

            var query = "SELECT * FROM public.estimation ORDER BY \"idEstimation\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idEstimation = (string) reader["idEstimation"];
                var produitId = (string) reader["produitId"];
                var commissaireId = (string) reader["commissaireId"];
                var dateEstimation = (DateTime) reader["dateEstimation"];
                var prixEstimation = (double) reader["prixEstimation"];

                liste.Add(new EstimationDAO(idEstimation, produitId, commissaireId,dateEstimation,prixEstimation));
            }

            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewEstimation(EstimationDAO estimation)
        {
            // Inserer estimation dans la bdd
            var query =
                @"INSERT INTO public.estimation (""idEstimation"",""produitId"",""commissaireId"",""dateEstimation"",""prixEstimation"") 
values (:idEstimation,:produitId,:commissaireId,:dateEstimation,:prixEstimation) 
ON CONFLICT ON CONSTRAINT pk_estimation DO UPDATE SET ""idEstimation""=:idEstimation,
""produitId""=:produitId,
""commissaireId""=:commissaireId,
""dateEstimation""=:dateEstimation,
""prixEstimation""=:prixEstimation,
where estimation.""idEstimation""=:idEstimation";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idEstimation", estimation.IdEstimation);
            cmd.Parameters.AddWithValue("produitId", estimation.ProduitId);
            cmd.Parameters.AddWithValue("commissaireId", estimation.CommissaireId);
            cmd.Parameters.AddWithValue("dateEstimation", estimation.DateEstimation.ToTimestamp());
            cmd.Parameters.AddWithValue("prixEstimation", estimation.PrixEstimation);
            
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeleteEstimation(string estimationId)
        {
            // Supprimer estimation dans la bdd
            EstimationDAO dao = SelectEstimationById(estimationId);
            if (dao.IdEstimation != null)
            {
                var query = "DELETE FROM public.estimation WHERE \"idEstimation\"= :idEstimation";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idEstimation", estimationId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
