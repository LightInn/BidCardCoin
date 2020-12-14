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
    public static class ProduitDAL
    {
        // SELECT
        public static ProduitDAO SelectProduitById(string id)
        {
            ProduitDAO produitDao = new ProduitDAO();
            // Selectionne la produit a partir de l'id
            var query =
                "SELECT * FROM public.produit a where a.\"idProduit\"=:idProduitParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idProduitParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idProduit = (string) reader["idProduit"];
                var lotId = (string) reader["lotId"];
                var utilisateurId = (string) reader["utilisateurId"];
                var stockId = Convert.IsDBNull(reader["stockId"]) ? null : (string) reader["stockId"];
                var enchereGagnanteId = Convert.IsDBNull(reader["enchereGagnanteId"])
                    ? null
                    : (string) reader["enchereGagnanteId"];
                var nomArtiste = Convert.IsDBNull(reader["nomArtiste"]) ? null : (string) reader["nomArtiste"];
                var nomStyle = Convert.IsDBNull(reader["nomStyle"]) ? null : (string) reader["nomStyle"];
                var nomProduits = Convert.IsDBNull(reader["nomProduits"])
                    ? null
                    : (string) reader["nomProduits"];
                var prixReserve = Convert.IsDBNull((double) reader["prixReserve"])
                    ? -1
                    : (double) reader["prixReserve"];
                var referenceCatalogue = Convert.IsDBNull(reader["referenceCatalogue"])
                    ? null
                    : (string) reader["referenceCatalogue"];
                var descriptionProduit = Convert.IsDBNull(reader["descriptionProduit"])
                    ? null
                    : (string) reader["descriptionProduit"];
                var isSend = (bool) reader["isSend"];

                produitDao = new ProduitDAO(idProduit, lotId, utilisateurId, stockId, enchereGagnanteId,
                    new List<string>(),
                    nomArtiste, nomStyle, nomProduits, prixReserve, referenceCatalogue, descriptionProduit, isSend);
            }

            reader.Close();

            query =
                "SELECT \"categorieId\" FROM public.categorie as c, public.categorieproduit as cp  where cp.\"produitId\" = c.\"idProduit\" and c.\"idProduit\" =:id";
            cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("id", produitDao.IdProduit);
            reader = cmd.ExecuteReader();
            List<string> produitlisteDao = new List<string>();
            while (reader.Read())
            {
                var categorie = (string) reader["categorieId"];
                produitlisteDao.Add(categorie);
            }

            produitDao.CategorieId = produitlisteDao;
            reader.Close();


            return produitDao;
        }

        public static List<ProduitDAO> SelectAllProduit()
        {
            // Selectionné tout les produit dans la base de donnée
            List<ProduitDAO> liste = new List<ProduitDAO>();

            var query = "SELECT * FROM public.produit ORDER BY \"idProduit\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // récup les paramètres principaux
                var idProduit = (string) reader["idProduit"];
                var lotId = (string) reader["lotId"];
                var utilisateurId = (string) reader["utilisateurId"];
                var stockId = Convert.IsDBNull(reader["stockId"]) ? null : (string) reader["stockId"];
                var enchereGagnanteId = Convert.IsDBNull(reader["enchereGagnanteId"])? String.Empty : (string) reader["enchereGagnanteId"];
                var nomArtiste = Convert.IsDBNull(reader["nomArtiste"]) ? null : (string) reader["nomArtiste"];
                var nomStyle = Convert.IsDBNull(reader["nomStyle"]) ? null : (string) reader["nomStyle"];
                var nomProduits = Convert.IsDBNull(reader["nomProduits"])
                    ? null
                    : (string) reader["nomProduits"];
                var prixReserve = Convert.IsDBNull((double) reader["prixReserve"])
                    ? -1
                    : (double) reader["prixReserve"];
                var referenceCatalogue = Convert.IsDBNull(reader["referenceCatalogue"])
                    ? null
                    : (string) reader["referenceCatalogue"];
                var descriptionProduit = Convert.IsDBNull(reader["descriptionProduit"])
                    ? null
                    : (string) reader["descriptionProduit"];
                var isSend = (bool) reader["isSend"];
                // var photoId = Convert.IsDBNull(reader["photoId"]) ? null : (string) reader["photoId"];

                liste.Add(new ProduitDAO(idProduit, lotId, utilisateurId, stockId, enchereGagnanteId,
                    new List<string>(),
                    nomArtiste, nomStyle, nomProduits, prixReserve, referenceCatalogue, descriptionProduit, isSend));
            }

            reader.Close();

            foreach (var produitDao in liste)
            {
                query =
                    "SELECT \"categorieId\" FROM public.categorie as c, public.categorieproduit as cp  where cp.\"produitId\" = c.\"idProduit\" and c.\"idProduit\" =:id";
                cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("id", produitDao.IdProduit);
                reader = cmd.ExecuteReader();
                List<string> produitlisteDao = new List<string>();
                while (reader.Read())
                {
                    var categorie = (string) reader["categorieId"];
                    produitlisteDao.Add(categorie);
                }

                produitDao.CategorieId = produitlisteDao;
                reader.Close();
            }

            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewProduit(ProduitDAO produit)
        {
            // Inserer produit dans la bdd
            var query =
                @"INSERT INTO public.produit (""idProduit"",""lotId"",""utilisateurId"",""stockId"",""enchereGagnanteId"",""nomArtiste"",""nomStyle"",""nomProduits"",""prixReserve"",""referenceCatalogue"",""descriptionProduit"",""isSend"") 
values (:idProduit,:lotId,:utilisateurId,:stockId,:enchereGagnanteId,:nomArtiste,:nomStyle,:nomProduits,:prixReserve,:referenceCatalogue,:descriptionProduit,:isSend) 
ON CONFLICT ON CONSTRAINT pk_produit DO UPDATE SET ""idProduit""=:idProduit,
""lotId""=:lotId,
""utilisateurId""=:utilisateurId,
""stockId""=:stockId,
""enchereGagnanteId""=:enchereGagnanteId,
""nomArtiste""=:nomArtiste,
""nomStyle""=:nomStyle,
""nomProduits""=:nomProduits,
""prixReserve""=:prixReserve,
""referenceCatalogue""=:referenceCatalogue,
""descriptionProduit""=:descriptionProduit,
""isSend""=:isSend,
where produit.""idProduit""=:idProduit";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idProduit", produit.IdProduit);
            cmd.Parameters.AddWithValue("lotId", produit.LotId);
            cmd.Parameters.AddWithValue("utilisateurId", produit.UtilisateurId);
            cmd.Parameters.AddWithValue("stockId", produit.StockId);
            cmd.Parameters.AddWithValue("enchereGagnanteId", produit.EnchereGagnanteId);
            cmd.Parameters.AddWithValue("nomArtiste", produit.NomArtiste);
            cmd.Parameters.AddWithValue("nomStyle", produit.NomStyle);
            cmd.Parameters.AddWithValue("nomProduits", produit.NomProduit);
            cmd.Parameters.AddWithValue("prixReserve", produit.PrixReserve);
            cmd.Parameters.AddWithValue("referenceCatalogue", produit.ReferenceCatalogue);
            cmd.Parameters.AddWithValue("descriptionProduit", produit.DescriptionProduit);
            cmd.Parameters.AddWithValue("isSend", produit.IsSend);
            // cmd.Parameters.AddWithValue("photoId", produit.PhotoId);

            foreach (var categorie in produit.CategorieId)
            {
                query =
                    @"INSERT INTO public.produit (""categorieId"",""lotId"") 
values (:categorieId,:produitId) 
ON CONFLICT ON CONSTRAINT pk_produit DO UPDATE SET ""produitId""=:produitId,
""categorieId""=:categorieId,
where produit.""produitId""=:produitId";
                cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("categorieId", categorie);
                cmd.Parameters.AddWithValue("produitId", produit.IdProduit);
                cmd.ExecuteNonQuery();
            }

            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeleteProduit(string produitId)
        {
            // Supprimer produit dans la bdd
            ProduitDAO dao = SelectProduitById(produitId);
            if (dao.IdProduit != null)
            {
                var query = "DELETE FROM public.produit WHERE \"idProduit\"=:idProduit";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idProduit", produitId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}