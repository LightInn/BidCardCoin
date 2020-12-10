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
    public static class PersonneDAL
    {
        // SELECT
        public static PersonneDAO SelectPersonneById(string id)
        {
            PersonneDAO personneDao = new PersonneDAO();
            // Selectionne la personne a partir de l'id
            var query =
                "SELECT * FROM public.personne a where a.\"idPersonne\"= :idPersonneParam";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idPersonneParam", id);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // récup les paramètres principaux
                var idPersonne = (string) reader["idPersonne"];
                var nom = (string) reader["nom"];
                var prenom = (string) reader["prenom"];
                var age = (int) reader["age"];
                var email = (string) reader["email"];
                var password = (string) reader["password"];
                var telephoneMobile = (string) reader["telephoneMobile"];
                var telephoneFixe = (string) reader["telephoneFixe"];
                
                return new PersonneDAO(idPersonne,nom,prenom,age,email,password,telephoneMobile,telephoneFixe);
            }

            return new PersonneDAO();
        }

        public static List<PersonneDAO> SelectAllPersonne()
        {
            // Selectionné tout les personne dans la base de donnée
            List<PersonneDAO> liste = new List<PersonneDAO>();

            var query = "SELECT * FROM public.personne ORDER BY \"idPersonne\"";
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

                liste.Add(new PersonneDAO(idPersonne,nom,prenom,age,email,password,telephoneMobile,telephoneFixe));
            }

            return liste;
        }

        // INSERT & Update 
        public static void InsertOrAddNewPersonne(PersonneDAO personne)
        {
            // Inserer personne dans la bdd
            var query =
                @"INSERT INTO public.personne (""idPersonne"",""nom"",""prenom"",""age"",""email"",""password"",""telephoneMobile"",""telephoneFixe"") 
values (:idPersonne,:nom,:prenom,:age,:email,:password,:telephoneMobile,:telephoneFixe) 
ON CONFLICT ON CONSTRAINT pk_personne DO UPDATE SET ""idPersonne""=:idPersonne,
""nom""=:nom,
""prenom""=:prenom,
""age""=:age,
""email""=:email,
""password""=:password,
""telephoneMobile""=:telephoneMobile,
""telephoneFixe""=:telephoneFixe,
where personne.""idPersonne""=:idPersonne";
            var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
            cmd.Parameters.AddWithValue("idPersonne", personne.IdPersonne);
            cmd.Parameters.AddWithValue("nom", personne.Nom);
            cmd.Parameters.AddWithValue("prenom", personne.Prenom);
            cmd.Parameters.AddWithValue("age", personne.Age);
            cmd.Parameters.AddWithValue("email", personne.Email);
            cmd.Parameters.AddWithValue("password", personne.Password);
            cmd.Parameters.AddWithValue("telephoneMobile", personne.TelephoneFixe);
            cmd.Parameters.AddWithValue("telephoneFixe", personne.TelephoneFixe);
            
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public static void DeletePersonne(string personneId)
        {
            // Supprimer personne dans la bdd
            PersonneDAO dao = SelectPersonneById(personneId);
            if (dao.IdPersonne != null)
            {
                var query = "DELETE FROM public.personne WHERE \"idPersonne\"= :idPersonne";
                var cmd = new NpgsqlCommand(query, DALconnection.OpenConnection());
                cmd.Parameters.AddWithValue("idPersonne", personneId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}