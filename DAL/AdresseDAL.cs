using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
     public static class AdresseDAL
    {
// SELECT

        public static AdresseDAO SelectAdresseById(string id)
        {
            // Selectionne l'adresse a partir de l'id
            var query = "SELECT * FROM public.adresse ORDER BY \"idAdresse\" where \"idAdresse\"=(@idAdresse)";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idAdresse", id);

            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                var idAdresse = (string) reader["idAdresse"];
                var pays = (string) reader["pays"];
                var region = (string) reader["region"];
                var ville = (string) reader["ville"];
                var codePostal = (string) reader["codePostal"];
                var adresse = (string) reader["adresse"];

                return new AdresseDAO(idAdresse, pays, region, ville, codePostal, adresse);
            }

            return new AdresseDAO();
        }


        public static List<AdresseDAO> SelectAllAdresse()
        {
            // Selectionné tout les adresse dans la base de donnée
            List<AdresseDAO> liste = new List<AdresseDAO>();

            var query = "SELECT * FROM public.adresse ORDER BY \"idAdresse\"";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idAdresse = (string) reader["idAdresse"];
                var pays = (string) reader["pays"];
                var region = (string) reader["region"];
                var ville = (string) reader["ville"];
                var codePostal = (string) reader["codePostal"];
                var adresse = (string) reader["adresse"];


                liste.Add(new AdresseDAO(idAdresse, pays, region, ville, codePostal, adresse));
            }

            return liste;
        }
        
        // INSERT

        public static void InsertNewAdresse(AdresseDAO adresse)
        {
            // Inserer adresse dans la bdd
            AdresseDAO dao = SelectAdresseById(adresse.IdAdresse);
            if (dao.IdAdresse == null)
            {
            }
            else
            {
                var query =
                    "INSERT INTO public.adresse values ((@idAdresse),(@pays),(@region),(@ville),(@codePostal),(@adresse))";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idAdresse", adresse.IdAdresse);
                cmd.Parameters.AddWithValue("pays", adresse.Pays);
                cmd.Parameters.AddWithValue("region", adresse.Region);
                cmd.Parameters.AddWithValue("ville", adresse.Ville);
                cmd.Parameters.AddWithValue("codePostal", adresse.CodePostal);
                cmd.Parameters.AddWithValue("adresse", adresse.Adresse);
                cmd.ExecuteNonQuery();
            }
        }
// UPDATE

        public static void UpdateAdresse(AdresseDAO adresse)
        {
            // Mettre a jour adresse dans la bdd
            AdresseDAO dao = SelectAdresseById(adresse.IdAdresse);
            if (dao.IdAdresse == null)
            {
            }
            else
            {
                var query = "UPDATE public.adresse SET (idAdresse=(@idAdresse),pays=(@pays),region=(@region),ville=(@ville),codePostal=(@codePostal),adresse=(@adresse))";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idAdresse", adresse.IdAdresse);
                cmd.Parameters.AddWithValue("pays", adresse.Pays);
                cmd.Parameters.AddWithValue("region", adresse.Region);
                cmd.Parameters.AddWithValue("ville", adresse.Ville);
                cmd.Parameters.AddWithValue("codePostal", adresse.CodePostal);
                cmd.Parameters.AddWithValue("adresse", adresse.Adresse);
                cmd.ExecuteNonQuery();
            }
        }

// DELETE


        public static void DeleteAdresse(string adresseId)
        {
            // Supprimer adresse dans la bdd
            
            AdresseDAO dao = SelectAdresseById(adresseId);
            if (dao.IdAdresse == null)
            {
            }
            else
            {
                var query = "DELETE FROM public.adresse WHERE \"idAdresse\"=(@idAdresse))";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idAdresse", adresseId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}