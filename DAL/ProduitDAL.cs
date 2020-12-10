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
                "SELECT * FROM public.produit a where a.\"idProduit\"= :idProduitParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idProduitParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idProduit = (string) reader["idProduit"];
                var lotId = (string) reader["lotId"];
                var utilisateurId = (string) reader["utilisateurId"];
                var stockId = (string) reader["stockId"];
                var enchereGagnanteId = (string) reader["enchereGagnanteId"];
                var nomArtiste = (string) reader["nomArtiste"];
                var nomStyle = (string) reader["nomStyle"];
                var nomProduits = (string) reader["nomProduits"];
                var prixReserve = (double) reader["prixReserve"];
                var referenceCatalogue = (string) reader["referenceCatalogue"];
                var descriptionProduit = (string) reader["descriptionProduit"];
                var isSend = (bool) reader["isSend"];
                
                return new ProduitDAO(idProduit, lotId, utilisateurId,stockId,enchereGagnanteId,nomArtiste,nomStyle,nomProduits,prixReserve,referenceCatalogue,descriptionProduit,isSend);
            }

            return new ProduitDAO();
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
                var stockId = (string) reader["stockId"];
                var enchereGagnanteId = (string) reader["enchereGagnanteId"];
                var nomArtiste = (string) reader["nomArtiste"];
                var nomStyle = (string) reader["nomStyle"];
                var nomProduits = (string) reader["nomProduits"];
                var prixReserve = (double) reader["prixReserve"];
                var referenceCatalogue = (string) reader["referenceCatalogue"];
                var descriptionProduit = (string) reader["descriptionProduit"];
                var isSend = (bool) reader["isSend"];
                
                liste.Add(new ProduitDAO(idProduit, lotId, utilisateurId,stockId,enchereGagnanteId,nomArtiste,nomStyle,nomProduits,prixReserve,referenceCatalogue,descriptionProduit,isSend));
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
            
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeleteProduit(string produitId)
        {
            // Supprimer produit dans la bdd
            ProduitDAO dao = SelectProduitById(produitId);
            if (dao.IdProduit != null)
            {
                var query = "DELETE FROM public.produit WHERE \"idProduit\"= :idProduit";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idProduit", produitId);
                cmd.ExecuteNonQuery();
            }
        }
            
    }
}
