using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;
using Npgsql;

namespace bidCardCoin.DAL
{
    public static class PersonneDAL
    {
        // SELECT


        public static PersonneDAO SelectPersonneById(string id)

        {
            // Selectionné l'Personne a partir de l'id


            PersonneDAO dao = new PersonneDAO();

            var query = "SELECT * FROM public.personne  where \"idPersonne\" = :id";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("id", id);
            var reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                var idPersonne = (string) reader["idPersonne"];
                var nom = (string) reader["nom"];
                var prenom = (string) reader["prenom"];
                var age = (int) reader["age"];
                var email = (string) reader["email"];
                var password = (string) reader["password"];
                var telephoneMobile = (string) reader["telephoneMobile"];
                var telephoneFixe = Convert.IsDBNull(reader["telephoneFixe"]) ? null : (string) reader["telephoneFixe"];

                dao = new PersonneDAO(idPersonne, nom, prenom, age, email, password, telephoneMobile, telephoneFixe,
                    new List<string>());
            }

            reader.Close();

            query =
                "SELECT \"adresseId\" FROM public.personne as p, public.adressepersonne as ap  where ap.\"personneId\" = p.\"idPersonne\" and p.\"idPersonne\" = :id";
            cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("id", id);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var adresseId = (string) reader["adresseId"];
                dao.Adresses.Add(adresseId);
            }

            reader.Close();
            dao.ChildReference = getChildReference(dao.IdPersonne);

            return dao;
        }


        public static List<PersonneDAO> SelectAllPersonne()
        {
            // Selectionné tout les Personne dans la base de donnée


            List<PersonneDAO> liste = new List<PersonneDAO>();

            var query = "SELECT * FROM public.personne";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            var reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                var idPersonne = (string) reader["idPersonne"];
                var nom = (string) reader["nom"];
                var prenom = (string) reader["prenom"];
                var age = (int) reader["age"];
                var email = (string) reader["email"];
                var password = (string) reader["password"];
                var telephoneMobile = (string) reader["telephoneMobile"];
                var telephoneFixe = (string) reader["telephoneFixe"];

                liste.Add(new PersonneDAO(idPersonne, nom, prenom, age, email, password, telephoneMobile, telephoneFixe,
                    new List<string>()));
            }

            reader.Close();

            foreach (var personneDao in liste)
            {
                query =
                    "SELECT \"adresseId\" FROM public.personne as p, public.adressepersonne as ap  where ap.\"personneId\" = p.\"idPersonne\" and p.\"idPersonne\" = :id";
                cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("id", personneDao.IdPersonne);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var adresseId = (string) reader["adresseId"];
                    personneDao.Adresses.Add(adresseId);
                }

                reader.Close();
                personneDao.ChildReference = getChildReference(personneDao.IdPersonne);
            }

            return liste;
        }

        public static string getChildReference(string id)
        {
            var query =
                "select u.\"idUtilisateur\" from public.utilisateur as u, public.personne as p where p.\"idPersonne\" = u.\"personneId\" and p.\"idPersonne\" = :id";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("id", id);
            return (string) cmd.ExecuteScalar();
        }


// INSERT

        public static void InsertNewPersonne(PersonneDAO personne)
        {
            // Inserer Personne dans la bdd


            var query =
                "INSERT INTO public.personne (\"idPersonne\",\"nom\", \"prenom\", \"age\", \"email\",\"password\", \"telephoneMobile\", \"telephoneFixe\") VALUES (:idPersonne, :nom, :prenom, :age, :email,:password, :telephoneMobile, :telephoneFixe)";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idPersonne", personne.IdPersonne);
            cmd.Parameters.AddWithValue("nom", personne.Nom);
            cmd.Parameters.AddWithValue("prenom", personne.Prenom);
            cmd.Parameters.AddWithValue("age", personne.Age);
            cmd.Parameters.AddWithValue("email", personne.Email);
            cmd.Parameters.AddWithValue("password", personne.Password);
            cmd.Parameters.AddWithValue("telephoneMobile", personne.TelephoneMobile);
            cmd.Parameters.AddWithValue("telephoneFixe", personne.TelephoneFixe);

            cmd.ExecuteNonQuery();

            foreach (var adresse in personne.Adresses)
            {
                query =
                    "INSERT INTO public.adressepersonne (\"personneId\",\"adresseId\") VALUES (:idPersonne, :adresseId)";
                cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idPersonne", personne.IdPersonne);
                cmd.Parameters.AddWithValue("adresseId", adresse);
                cmd.ExecuteNonQuery();
            }
        }


// UPDATE

        public static void UpdatePersonne(PersonneDAO personne)
        {
            // Mettre a jour Personne dans la bdd


            var query =
                "UPDATE public.personne SET \"idPersonne\" = :idPersonne,\"nom\"= :nom, \"prenom\" = :prenom, \"age\"= :age, \"email\"= :email,\"password\"= :password, \"telephoneMobile\"= :telephoneMobile, \"telephoneFixe\"= :telephoneFixe where \"idPersonne\"  = :idPersonne";


            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idPersonne", personne.IdPersonne);
            cmd.Parameters.AddWithValue("nom", personne.Nom);
            cmd.Parameters.AddWithValue("prenom", personne.Prenom);
            cmd.Parameters.AddWithValue("age", personne.Age);
            cmd.Parameters.AddWithValue("email", personne.Email);
            cmd.Parameters.AddWithValue("password", personne.Password);
            cmd.Parameters.AddWithValue("telephoneMobile", personne.TelephoneMobile);
            cmd.Parameters.AddWithValue("telephoneFixe", personne.TelephoneFixe);

            cmd.ExecuteNonQuery();


            foreach (var adresse in personne.Adresses)
            {
                query =
                    "INSERT INTO public.adressepersonne (\"personneId\",\"adresseId\") VALUES (:idPersonne, :adresseId) ON conflict do UPDATE SET \"personneId\"  = :idPersonne, \"adresseId\" = :adresseId";


                cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idPersonne", personne.IdPersonne);
                cmd.Parameters.AddWithValue("adresseId", adresse);
                cmd.ExecuteNonQuery();
            }
        }


// DELETE

        public static void DeletePersonne(string id)
        {
            // Supprimer Personne dans la bdd


            var query = "DELETE FROM public.personne WHERE \"idPersonne\" = :id;";

            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}