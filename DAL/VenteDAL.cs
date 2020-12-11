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
    public static class VenteDAL
    {
        // SELECT
        public static VenteDAO SelectVenteById(string id)
        {
            VenteDAO venteDao = new VenteDAO();
            // Selectionne la vente a partir de l'id
            var query =
                "SELECT * FROM public.vente a where a.\"idVente\"= :idVenteParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idVenteParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idVente = (string) reader["idVente"];
                var lotId = (string) reader["lotId"];
                var adresseId = (string) reader["adresseId"];
                var dateDebut = (DateTime) reader["dateDebut"];
                
                
                return new VenteDAO(idVente, lotId, adresseId,dateDebut);
            }

            return new VenteDAO();
        }

        public static List<VenteDAO> SelectAllVente()
        {
            // Selectionné tout les vente dans la base de donnée
            List<VenteDAO> liste = new List<VenteDAO>();

            var query = "SELECT * FROM public.vente ORDER BY \"idVente\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idVente = (string) reader["idVente"];
                var lotId = (string) reader["lotId"];
                var adresseId = (string) reader["adresseId"];
                var dateDebut = (DateTime) reader["dateDebut"];
                
                liste.Add( new VenteDAO(idVente, lotId, adresseId,dateDebut));
            }

            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewVente(VenteDAO vente)
        {
            // Inserer vente dans la bdd
            var query =
                @"INSERT INTO public.vente (""idVente"",""lotId"",""adresseId"",""dateDebut"") 
values (:idVente,:lotId,:commissaireId,:dateVente,:prixVente) 
ON CONFLICT ON CONSTRAINT pk_vente DO UPDATE SET ""idVente""=:idVente,
""lotId""=:lotId,
""adresseId""=:adresseId,
""dateDebut""=:dateDebut,
where vente.""idVente""=:idVente";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idVente", vente.IdVente);
            cmd.Parameters.AddWithValue("lotId", vente.LotId);
            cmd.Parameters.AddWithValue("adresseId", vente.AdresseId);
            cmd.Parameters.AddWithValue("dateDebut", vente.DateDebut);
            
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeleteVente(string venteId)
        {
            // Supprimer vente dans la bdd
            VenteDAO dao = SelectVenteById(venteId);
            if (dao.IdVente != null)
            {
                var query = "DELETE FROM public.vente WHERE \"idVente\"= :idVente";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idVente", venteId);
                cmd.ExecuteNonQuery();
            }
        }
            
    }
}
