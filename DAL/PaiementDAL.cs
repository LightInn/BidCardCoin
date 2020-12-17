using System.Collections.Generic;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
    public static class PaiementDAL
    {
// SELECT
        public static PaiementDAO SelectPaiementById(string id)
        {
            var paiementDao = new PaiementDAO();
            // Selectionne la paiement a partir de l'id
            var query =
                "SELECT * FROM public.paiement a where a.\"idPaiement\"=:idPaiementParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idPaiementParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idPaiement = (string) reader["idPaiement"];
                var utilisateurId = (string) reader["utilisateurId"];
                var lotId = (string) reader["lotId"];
                var typePaiement = (string) reader["typePaiement"];
                var validationPaiement = (bool) reader["validationPaiement"];
                paiementDao = new PaiementDAO(idPaiement, lotId, utilisateurId, typePaiement, validationPaiement);
            }

            reader.Close();
            return paiementDao;
        }

        public static List<PaiementDAO> SelectAllPaiement()
        {
            // Selectionné tout les paiement dans la base de donnée
            var liste = new List<PaiementDAO>();

            var query = "SELECT * FROM public.paiement ORDER BY \"idPaiement\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idPaiement = (string) reader["idPaiement"];
                var utilisateurId = (string) reader["utilisateurId"];
                var lotId = (string) reader["lotId"];
                var typePaiement = (string) reader["typePaiement"];
                var validationPaiement = (bool) reader["validationPaiement"];

                liste.Add(new PaiementDAO(idPaiement, lotId, utilisateurId, typePaiement, validationPaiement));
            }

            reader.Close();
            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewPaiement(PaiementDAO paiement)
        {
            // Inserer paiement dans la bdd
            var query =
                @"INSERT INTO public.paiement (""idPaiement"",""utilisateurId"",""lotId"",""typePaiement"",""validationPaiement"") 
values (:idPaiement,:utilisateurId,:lotId,:typePaiement,:validationPaiement) 
ON CONFLICT ON CONSTRAINT pk_paiement DO UPDATE SET ""idPaiement""=:idPaiement,
""utilisateurId""=:utilisateurId,
""lotId""=:lotId,
""typePaiement""=:typePaiement,
""validationPaiement""=:validationPaiement,
where paiement.""idPaiement""=:idPaiement";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idPaiement", paiement.IdPaiement);
            cmd.Parameters.AddWithValue("utilisateurId", paiement.UtilisateurId);
            cmd.Parameters.AddWithValue("lotId", paiement.LotId);
            cmd.Parameters.AddWithValue("typePaiement", paiement.TypePaiement);
            cmd.Parameters.AddWithValue("validationPaiement", paiement.ValidationPaiement);

            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeletePaiement(string paiementId)
        {
            // Supprimer paiement dans la bdd
            var dao = SelectPaiementById(paiementId);
            if (dao.IdPaiement != null)
            {
                var query = "DELETE FROM public.paiement WHERE \"idPaiement\"=:idPaiement";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idPaiement", paiementId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}