using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
    public static class EnchereDAL
    {
        // SELECT ---------------------------------------------------------------------

        public static EnchereDAO SelectEnchereById(string id)

        {
            // Selectionné l'Enchere a partir de l'id

            EnchereDAO dao = new EnchereDAO();

            var query = "SELECT * FROM public.enchere  where \"idEnchere\" =:id";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("id", id);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idEnchere = (string) reader["idEnchere"];
                var prixProposer = (double) reader["prixProposer"];
                var estAdjuger = (bool) reader["estAdjuger"];
                var dateHeureVente = (DateTime) reader["dateHeureVente"];
                var lotId = (string) reader["lotId"];
                var commissaireId = (string) reader["commissaireId"];

                var sender = Convert.IsDBNull(reader["ordreAchatId"])
                    ? (string) reader["utilisateurId"]
                    : (string) reader["ordreAchatId"];
                dao = Convert.IsDBNull(reader["ordreAchatId"])
                    ? new EnchereDAO(idEnchere, prixProposer, estAdjuger, dateHeureVente, lotId, commissaireId, null,
                        sender)
                    : new EnchereDAO(idEnchere, prixProposer, estAdjuger, dateHeureVente, lotId, commissaireId, sender,
                        null);
            }

            reader.Close();
            return dao;
        }


        public static List<EnchereDAO> SelectAllEnchere()
        {
            // Selectionné tout les Enchere dans la base de donnée
            List<EnchereDAO> liste = new List<EnchereDAO>();


            var query = "SELECT * FROM public.enchere ORDER BY \"idEnchere\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var idEnchere = (string) reader["idEnchere"];
                var prixProposer = (double) reader["prixProposer"];
                var estAdjuger = (bool) reader["estAdjuger"];
                var dateHeureVente = (DateTime) reader["dateHeureVente"];
                var lotId = (string) reader["lotId"];
                var commissaireId = (string) reader["commissaireId"];


                var sender = Convert.IsDBNull(reader["ordreAchatId"])
                    ? (string) reader["utilisateurId"]
                    : (string) reader["ordreAchatId"];
                var dao = Convert.IsDBNull(reader["ordreAchatId"])
                    ? new EnchereDAO(idEnchere, prixProposer, estAdjuger, dateHeureVente, lotId, commissaireId, null,
                        sender)
                    : new EnchereDAO(idEnchere, prixProposer, estAdjuger, dateHeureVente, lotId, commissaireId, sender,
                        null);
                liste.Add(dao);
            }

            reader.Close();
            return liste;
        }


// INSERT -------------------------------------------------------------------------------

        public static void InsertNewEnchere(EnchereDAO enchere)
        {
            // Inserer Enchere dans la bdd


            if (enchere.UtilisateurId != null)
            {
                var query =
                    "INSERT INTO public.enchere (\"idEnchere\", \"prixProposer\", \"estAdjuger\", \"dateHeureVente\",\"lotId\", \"commissaireId\", \"utilisateurId\") VALUES (:idEnchere ,:prix ,:adjuger ,:timestamp  ,:lotId ,:commissaireId ,:utilisateurId )";

                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idEnchere", enchere.IdEnchere);
                cmd.Parameters.AddWithValue("prix", enchere.PrixProposer);
                cmd.Parameters.AddWithValue("adjuger", enchere.EstAdjuger);
                cmd.Parameters.AddWithValue("timestamp", enchere.DateHeureVente);
                cmd.Parameters.AddWithValue("lotId", enchere.LotId);
                cmd.Parameters.AddWithValue("commissaireId", enchere.CommissaireId);
                cmd.Parameters.AddWithValue("utilisateurId", enchere.UtilisateurId);

                cmd.ExecuteNonQuery();
            }
            else
            {
                var query =
                    "INSERT INTO public.enchere (\"idEnchere\", \"prixProposer\", \"estAdjuger\", \"dateHeureVente\",\"lotId\", \"commissaireId\", \"ordreAchatId\") VALUES (:idEnchere ,:prix ,:adjuger ,:timestamp ,:lotId ,:commissaireId ,:ordreAchatId )";

                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idEnchere", enchere.IdEnchere);
                cmd.Parameters.AddWithValue("prix", enchere.PrixProposer);
                cmd.Parameters.AddWithValue("adjuger", enchere.EstAdjuger);
                cmd.Parameters.AddWithValue("timestamp", enchere.DateHeureVente);
                cmd.Parameters.AddWithValue("lotId", enchere.LotId);
                cmd.Parameters.AddWithValue("commissaireId", enchere.CommissaireId);
                cmd.Parameters.AddWithValue("ordreAchatId", enchere.OrdreAchatId);

                cmd.ExecuteNonQuery();
            }
        }

// UPDATE -------------------------------------------------------------------------------

        public static void UpdateEnchere(EnchereDAO enchere)
        {
            // Mettre a jour Enchere dans la bdd

            var query =
                "UPDATE public.enchere SET \"idEnchere\" = @id, \"prixProposer\" = @prix ,\"estAdjuger\" = @adjuger , \"dateHeureVente\" = @timestamp, \"ordreAchatId\" = @ordreAchatId, \"lotId\" = @lotId, \"commissaireId\" = @commissaireId, \"utilisateurId\" = @utilisateurId, WHERE \"idEnchere\" = @id ";


            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("id", enchere.IdEnchere);
            cmd.Parameters.AddWithValue("prix", enchere.PrixProposer);
            cmd.Parameters.AddWithValue("adjuger", enchere.EstAdjuger);
            cmd.Parameters.AddWithValue("timestamp", enchere.DateHeureVente);
            cmd.Parameters.AddWithValue("ordreAchatId", enchere.OrdreAchatId);
            cmd.Parameters.AddWithValue("lotId", enchere.LotId);
            cmd.Parameters.AddWithValue("commissaireId", enchere.CommissaireId);
            cmd.Parameters.AddWithValue("utilisateurId", enchere.UtilisateurId);
            cmd.ExecuteNonQuery();
        }

// DELETE -------------------------------------------------------------------------------

        public static void DeleteEnchere(string id)
        {
            // Supprimer Enchere dans la bdd

            var query = "DELETE FROM public.adresse WHERE \"idAdresse\" = @id;";

            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}