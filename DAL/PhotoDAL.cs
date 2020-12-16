using System.Collections.Generic;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
    public static class PhotoDAL
    {
        // SELECT
        public static PhotoDAO SelectPhotoById(string id)
        {
            var photoDao = new PhotoDAO();
            // Selectionne la photo a partir de l'id
            var query =
                "SELECT * FROM public.photo a where a.\"idPhoto\"=:idPhotoParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idPhotoParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idPhoto = (string) reader["idPhoto"];
                var produitId = (string) reader["produitId"];
                var fichierPhoto = (string) reader["fichierPhoto"];

                photoDao = new PhotoDAO(idPhoto, produitId, fichierPhoto);
            }

            reader.Close();
            return photoDao;
        }

        public static List<PhotoDAO> SelectAllPhoto()
        {
            // Selectionné tout les photo dans la base de donnée
            var liste = new List<PhotoDAO>();

            var query = "SELECT * FROM public.photo ORDER BY \"idPhoto\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idPhoto = (string) reader["idPhoto"];
                var produitId = (string) reader["produitId"];
                var fichierPhoto = (string) reader["fichierPhoto"];

                liste.Add(new PhotoDAO(idPhoto, produitId, fichierPhoto));
            }

            reader.Close();
            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewPhoto(PhotoDAO photo)
        {
            // Inserer photo dans la bdd
            var query =
                @"INSERT INTO public.photo (""idPhoto"",""produitId"",""fichierPhoto"") 
values (:idPhoto,:produitId,:fichierPhoto) 
ON CONFLICT ON CONSTRAINT pk_photo DO UPDATE SET ""idPhoto""=:idPhoto,
""produitId""=:produitId,
""fichierPhoto""=:fichierPhoto,
where photo.""idPhoto""=:idPhoto";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idPhoto", photo.IdPhoto);
            cmd.Parameters.AddWithValue("produitId", photo.ProduitId);
            cmd.Parameters.AddWithValue("fichierPhoto", photo.FichierPhoto);

            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeletePhoto(string photoId)
        {
            // Supprimer photo dans la bdd
            var dao = SelectPhotoById(photoId);
            if (dao.IdPhoto != null)
            {
                var query = "DELETE FROM public.photo WHERE \"idPhoto\"=:idPhoto";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idPhoto", photoId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}