using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
    public class CategorieDAL
    {
        // SELECT
        public static CategorieDAO SelectCategorieById(string id)
        {
            CategorieDAO categorieDao = new CategorieDAO();
            // Selectionne la categorie a partir de l'id
            var query =
                "SELECT * FROM public.categorie a where a.\"idCategorie\"=:idCategorieParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idCategorieParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idCategorie = (string) reader["idCategorie"];
                var categorieId = Convert.IsDBNull((string) reader["categorieId"])? null : ((string) reader["categorieId"]);
                var nomCategorie = (string) reader["nomCategorie"];
                categorieDao = new CategorieDAO(idCategorie, categorieId, nomCategorie);
            }
            reader.Close();

            return categorieDao;
        }

        public static List<CategorieDAO> SelectAllCategorie()
        {
            // Selectionné tout les categorie dans la base de donnée
            List<CategorieDAO> liste = new List<CategorieDAO>();

            var query = "SELECT * FROM public.categorie ORDER BY \"idCategorie\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idCategorie = (string) reader["idCategorie"];
                var categorieId = Convert.IsDBNull((string) reader["categorieId"])? null : ((string) reader["categorieId"]);
                var nomCategorie = (string) reader["nomCategorie"];

                liste.Add(new CategorieDAO(idCategorie, categorieId, nomCategorie));
            }
            reader.Close();
            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewCategorie(CategorieDAO categorie)
        {
            // Inserer categorie dans la bdd
            var query =
                @"INSERT INTO public.categorie (""idCategorie"",""categorieId"",""nomCategorie"") values 
(:idCategorie,:categorieId,:nomCategorie) 
ON CONFLICT ON CONSTRAINT pk_categorie DO UPDATE SET 
""idCategorie""=:idCategorie,
""categorieId""=:categorieId,
""nomCategorie""=:nomCategorie,
where categorie.""idCategorie""=:idCategorie";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idCategorie", categorie.CategorieId);
            cmd.Parameters.AddWithValue("categorieId", categorie.IdCategorie);
            cmd.Parameters.AddWithValue("nomCategorie", categorie.NomCategorie);
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeleteCategorie(string categorieId)
        {
            // Supprimer categorie dans la bdd
            CategorieDAO dao = SelectCategorieById(categorieId);
            if (dao.IdCategorie != null)
            {
                var query = "DELETE FROM public.categorie WHERE \"idCategorie\"=:idCategorie";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idCategorie", categorieId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}