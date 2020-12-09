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
            // Selectionne l'categorie a partir de l'id
            var query =
                "SELECT * FROM public.categorie a where a.\"idCategorie\"= :idCategorieParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idCategorieParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idCategorie = (string) reader["idCategorie"];
                var nomCategorie = (string) reader["nomCategorie"];
                var categorieId = (string) reader["categorieId"];
                // todo verif
                if (categorieId == null)
                {
                    return new CategorieDAO(idCategorie, nomCategorie);
                }
                else
                {
                    return new CategorieDAO(idCategorie, categorieId, nomCategorie);
                }
            }

            return new CategorieDAO();
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
                var nomCategorie = (string) reader["nomCategorie"];
                var categorieId = (string) reader["categorieId"];
                // todo verif
                if (categorieId == null)
                {
                    liste.Add(new CategorieDAO(idCategorie, nomCategorie));
                }
                else
                {
                    liste.Add(new CategorieDAO(idCategorie, categorieId, nomCategorie));
                }
            }

            return liste;
        }

        // INSERT
        public static void InsertNewCategorie(CategorieDAO categorie)
        {
            // Inserer categorie dans la bdd
            CategorieDAO dao = SelectCategorieById(categorie.IdCategorie);
            if (dao.IdCategorie == null && categorie.IdCategorie != null)
            {
                if (categorie.CategorieId == null)
                {
                    var query =
                        "INSERT INTO public.categorie values (:idCategorie,null,:nomCategorie)";
                    var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                    cmd.Parameters.AddWithValue("idCategorie", categorie.IdCategorie);
                    cmd.Parameters.AddWithValue("categorieId", categorie.CategorieId);
                    cmd.Parameters.AddWithValue("nomCategorie", categorie.NomCategorie);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    var query =
                        "INSERT INTO public.categorie values (:idCategorie,:categorieId,:nomCategorie)";
                    var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                    cmd.Parameters.AddWithValue("idCategorie", categorie.IdCategorie);
                    cmd.Parameters.AddWithValue("categorieId", categorie.CategorieId);
                    cmd.Parameters.AddWithValue("nomCategorie", categorie.NomCategorie);
                    cmd.ExecuteNonQuery();
                }
            }
        }
// UPDATE
        public static void UpdateCategorie(CategorieDAO categorie)
        {
            CategorieDAO dao = SelectCategorieById(categorie.IdCategorie);
            if (dao.IdCategorie != null && categorie.IdCategorie != null)
            {
                if (categorie.CategorieId != null)
                {
                    var query =
                        "UPDATE public.categorie SET (idCategorie= :idCategorie,categorieId= :categorieId, nomCategorie= :nomCategorie)";
                    var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                    cmd.Parameters.AddWithValue("idCategorie", categorie.IdCategorie);
                    cmd.Parameters.AddWithValue("categorieId", categorie.CategorieId);
                    cmd.Parameters.AddWithValue("nomCategorie", categorie.NomCategorie);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    var query =
                        "UPDATE public.categorie SET (idCategorie= :idCategorie, nomCategorie= :nomCategorie)";
                    var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                    cmd.Parameters.AddWithValue("idCategorie", categorie.IdCategorie);
                    cmd.Parameters.AddWithValue("nomCategorie", categorie.NomCategorie);
                    cmd.ExecuteNonQuery();
                }
            }
        }

// DELETE
        public static void DeleteCategorie(string categorieId)
        {
            // Supprimer categorie dans la bdd
            CategorieDAO dao = SelectCategorieById(categorieId);
            if (dao.IdCategorie != null)
            {
                var query = "DELETE FROM public.categorie WHERE \"idCategorie\"= :idCategorie";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idCategorie", categorieId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}