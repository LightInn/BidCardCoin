using System;
using System.Collections.Generic;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
    public static class OrdreAchatDAL
    {
        // SELECT
        public static OrdreAchatDAO SelectOrdreAchatById(string id)
        {
            var ordreAchatDao = new OrdreAchatDAO();
            // Selectionne la ordreAchat a partir de l'id
            var query =
                "SELECT * FROM public.ordreAchat a where a.\"idOrdreAchat\"=:idOrdreAchatParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idOrdreAchatParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idOrdreAchat = (string) reader["idOrdreAchat"];
                var utilisateurId = (string) reader["utilisateurId"];
                var lotId = (string) reader["lotId"];
                var montantMax = (double) reader["montantMax"];
                var date = (DateTime) reader["date"];
                var informatiser = (bool) reader["informatiser"];
                ordreAchatDao = new OrdreAchatDAO(idOrdreAchat, utilisateurId, lotId, informatiser, montantMax, date);
            }

            reader.Close();
            return ordreAchatDao;
        }

        public static List<OrdreAchatDAO> SelectAllOrdreAchat()
        {
            // Selectionné tout les ordreAchat dans la base de donnée
            var liste = new List<OrdreAchatDAO>();

            var query = "SELECT * FROM public.ordreAchat ORDER BY \"idOrdreAchat\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idOrdreAchat = (string) reader["idOrdreAchat"];
                var utilisateurId = (string) reader["utilisateurId"];
                var lotId = (string) reader["lotId"];
                var montantMax = (double) reader["montantMax"];
                var date = (DateTime) reader["date"];
                var informatiser = (bool) reader["informatiser"];

                liste.Add(new OrdreAchatDAO(idOrdreAchat, utilisateurId, lotId, informatiser, montantMax, date));
            }

            reader.Close();
            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewOrdreAchat(OrdreAchatDAO ordreAchat)
        {
            // Inserer ordreAchat dans la bdd
            var query =
                @"INSERT INTO public.ordreAchat (""idOrdreAchat"",""utilisateurId"",""lotId"",""montantMax"",""date"",""informatiser"") 
values (:idOrdreAchat,:utilisateurId,:lotId,:montantMax,:date,:informatiser) 
ON CONFLICT ON CONSTRAINT pk_ordreAchat DO UPDATE SET ""idOrdreAchat""=:idOrdreAchat,
""utilisateurId""=:utilisateurId,
""lotId""=:lotId,
""montantMax""=:montantMax,
""date""=:date,
""informatiser""=:informatiser,
where ordreAchat.""idOrdreAchat""=:idOrdreAchat";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idOrdreAchat", ordreAchat.IdOrdreAchat);
            cmd.Parameters.AddWithValue("utilisateurId", ordreAchat.UtilisateurId);
            cmd.Parameters.AddWithValue("lotId", ordreAchat.LotId);
            cmd.Parameters.AddWithValue("montantMax", ordreAchat.MontantMax);
            cmd.Parameters.AddWithValue("date", ordreAchat.Date);
            cmd.Parameters.AddWithValue("informatiser", ordreAchat.Informatiser);

            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeleteOrdreAchat(string ordreAchatId)
        {
            // Supprimer ordreAchat dans la bdd
            var dao = SelectOrdreAchatById(ordreAchatId);
            if (dao.IdOrdreAchat != null)
            {
                var query = "DELETE FROM public.ordreAchat WHERE \"idOrdreAchat\"=:idOrdreAchat";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idOrdreAchat", ordreAchatId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}