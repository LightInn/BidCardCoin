using System;
using System.Collections.Generic;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
    public static class LotDAL
    {
        // SELECT
        public static LotDAO SelectLotById(string id)
        {
            var lotDao = new LotDAO();
            // Selectionne la lot a partir de l'id
            var query =
                "SELECT * FROM public.lot a where a.\"idLot\"=:idLotParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idLotParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idLot = (string) reader["idLot"];
                var nomLot = (string) reader["nomLot"];
                var description = Convert.IsDBNull(reader["description"]) ? null : (string) reader["description"];
                lotDao = new LotDAO(idLot, nomLot, description);
            }

            reader.Close();
            return lotDao;
        }

        public static List<LotDAO> SelectAllLot()
        {
            // Selectionné tout les lot dans la base de donnée
            var liste = new List<LotDAO>();

            var query = "SELECT * FROM public.lot ORDER BY \"idLot\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idLot = (string) reader["idLot"];
                var nomLot = (string) reader["nomLot"];
                var description = Convert.IsDBNull(reader["description"]) ? null : (string) reader["description"];

                liste.Add(new LotDAO(idLot, nomLot, description));
            }

            reader.Close();
            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewLot(LotDAO lot)
        {
            // Inserer lot dans la bdd
            var query =
                @"INSERT INTO public.lot (""idLot"",""nomLot"",""description"") 
values (:idLot,:nomLot,:description) 
ON CONFLICT ON CONSTRAINT pk_lot DO UPDATE SET ""idLot""=:idLot,
""nomLot""=:nomLot,
""description""=:description,
where lot.""idLot""=:idLot";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idLot", lot.IdLot);
            cmd.Parameters.AddWithValue("nomLot", lot.NomLot);
            cmd.Parameters.AddWithValue("description", lot.Description);

            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeleteLot(string lotId)
        {
            // Supprimer lot dans la bdd
            var dao = SelectLotById(lotId);
            if (dao.IdLot != null)
            {
                var query = "DELETE FROM public.lot WHERE \"idLot\"=:idLot";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idLot", lotId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}