using System.Collections.Generic;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
    public static class CommissaireDAL
    {
        // SELECT
        public static CommissaireDAO SelectCommissaireById(string id)
        {
            var commissaireDao = new CommissaireDAO();
            // Selectionne la commissaire a partir de l'id
            var query =
                "SELECT * FROM public.commissaire a where a.\"idCommissaire\"=:idCommissaireParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idCommissaireParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idCommissaire = (string) reader["idCommissaire"];
                var personneId = (string) reader["personneId"];
                commissaireDao = new CommissaireDAO(idCommissaire, personneId);
            }

            reader.Close();
            return commissaireDao;
        }

        public static List<CommissaireDAO> SelectAllCommissaire()
        {
            // Selectionné tout les commissaire dans la base de donnée
            var liste = new List<CommissaireDAO>();

            var query = "SELECT * FROM public.commissaire ORDER BY \"idCommissaire\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idCommissaire = (string) reader["idCommissaire"];
                var personneId = (string) reader["personneId"];

                liste.Add(new CommissaireDAO(idCommissaire, personneId));
            }

            reader.Close();
            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewCommissaire(CommissaireDAO commissaire)
        {
            // Inserer commissaire dans la bdd
            var query =
                @"INSERT INTO public.commissaire (""idCommissaire"",""personneId"") 
values (:idCommissaire,:personneId) 
ON CONFLICT ON CONSTRAINT pk_commissaire DO UPDATE SET ""idCommissaire""=:idCommissaire,
""personneId""=:personneId,
where commissaire.""idCommissaire""=:idCommissaire";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idCommissaire", commissaire.IdCommissaire);
            cmd.Parameters.AddWithValue("personneId", commissaire.PersonneId);

            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeleteCommissaire(string commissaireId)
        {
            // Supprimer commissaire dans la bdd
            var dao = SelectCommissaireById(commissaireId);
            if (dao.IdCommissaire != null)
            {
                var query = "DELETE FROM public.commissaire WHERE \"idCommissaire\"=:idCommissaire";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idCommissaire", commissaireId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}