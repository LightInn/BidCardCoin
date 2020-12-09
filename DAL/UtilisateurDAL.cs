using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
    public static class UtilisateurDAL
    {
        // SELECT


        public static UtilisateurDAO SelectUtilisateurById(string id)
        {
            // Selectionné l'Utilisateur a partir de l'id


            UtilisateurDAO dao = new UtilisateurDAO();

            var query = "SELECT * FROM public.utilisateur  where \"idUtilisateur\" = :id";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("id", id);
            var reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                var idUtilisateur = (string) reader["idUtilisateur"];
                var personneId = (string) reader["personneId"];
                var verifSolvable = (bool) reader["verifSolvable"];
                var verifRessortissant = (bool) reader["verifRessortissant"];
                var verifIdentite = (bool) reader["verifIdentite"];
                var listeMotClef = (List<string>) (reader["listeMotClef"] as string).Split(";").ToList();

                dao = new UtilisateurDAO(idUtilisateur, personneId, verifSolvable, verifRessortissant, verifIdentite,
                    listeMotClef);
            }

            reader.Close();
            return dao;
        }


        public static List<UtilisateurDAO> SelectAllUtilisateur()
        {
            // Selectionné tout les Utilisateur dans la base de donnée


            List<UtilisateurDAO> liste = new List<UtilisateurDAO>();

            var query = "SELECT * FROM public.utilisateur";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var idUtilisateur = (string) reader["idUtilisateur"];
                var personneId = (string) reader["personneId"];
                var verifSolvable = (bool) reader["verifSolvable"];
                var verifResortissant = (bool) reader["verifResortissant"];
                var verifIdentite = (bool) reader["verifIdentite"];
                var listeMotClef = (List<string>) (reader["listeMotClef"] as string).Split(";").ToList();

                liste.Add(new UtilisateurDAO(idUtilisateur, personneId, verifSolvable, verifResortissant, verifIdentite,
                    listeMotClef));
            }

            reader.Close();
            return liste;
        }


// INSERT

        public static void InsertNewUtilisateur(UtilisateurDAO utilisateur)
        {
            // Inserer Utilisateur dans la bdd


            var query =
                "INSERT INTO public.utilisateur (\"idUtilisateur\",\"personneId\", \"verifSolvable\", \"verifRessortissant\", \"verifIdentite\",\"listeMotClef\") VALUES(:idUtilisateur,:personneId, :verifSolvable, :verifRessortissant, :verifIdentite,:listeMotClef)";

            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());

            cmd.Parameters.AddWithValue("idUtilisateur", utilisateur.IdUtilisateur);
            cmd.Parameters.AddWithValue("personneId", utilisateur.PersonneId);
            cmd.Parameters.AddWithValue("verifSolvable", utilisateur.VerifSolvable);
            cmd.Parameters.AddWithValue("verifRessortissant", utilisateur.VerifRessortissant);
            cmd.Parameters.AddWithValue("verifIdentite", utilisateur.VerifIdentite);
            cmd.Parameters.AddWithValue("listeMotClef", String.Join(";", utilisateur.ListeMotClef));

            cmd.ExecuteNonQuery();
        }

// UPDATE

        public static void UpdateUtilisateur(UtilisateurDAO utilisateur)
        {
            // Mettre a jour Utilisateur dans la bdd


            var query =
                "UPDATE public.utilisateur SET \"idUtilisateur\" = :idUtilisateur ,\"personneId\" = :personneId  , \"verifSolvable\" = :verifSolvable , \"verifRessortissant\" = :verifRessortissant , \"verifIdentite\" = :verifIdentite ,\"listeMotClef\" = :listeMotClef  where \"idUtilisateur\"  = :idUtilisateur";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());

            cmd.Parameters.AddWithValue("idUtilisateur", utilisateur.IdUtilisateur);
            cmd.Parameters.AddWithValue("personneId", utilisateur.PersonneId);
            cmd.Parameters.AddWithValue("verifSolvable", utilisateur.VerifSolvable);
            cmd.Parameters.AddWithValue("verifRessortissant", utilisateur.VerifRessortissant);
            cmd.Parameters.AddWithValue("verifIdentite", utilisateur.VerifIdentite);
            cmd.Parameters.AddWithValue("listeMotClef", String.Join(";", utilisateur.ListeMotClef));

            cmd.ExecuteNonQuery();
        }

// DELETE

        public static void DeleteUtilisateur(string id)
        {
            // Supprimer Utilisateur dans la bdd
          
             var query = "DELETE FROM public.utilisateur WHERE \"idUtilisateur\" = :id;";

             var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
             cmd.Parameters.AddWithValue("id", id);
             cmd.ExecuteNonQuery();


}
    }
}

