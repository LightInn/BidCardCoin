using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class PersonneDAL
    {
        // SELECT


        public static PersonneDAO SelectPersonneById(string id)

        {
            // Selectionné l'Personne a partir de l'id
            return new PersonneDAO();
        }


        public static List<PersonneDAO> SelectAllPersonne()
        {
            // Selectionné tout les Personne dans la base de donnée
            return new List<PersonneDAO>();
        }


// INSERT

        public static void InsertNewPersonne(PersonneDAO Personne)
        {
            // Inserer Personne dans la bdd


            //     INSERT INTO public.personne (
            //     "idPersonne", "nom", "prenom", "age", "email",
            //     "password", "telephoneMobile", "telephoneFixe"
            // ) VALUES (
            //     'f13d24de-39f2-11eb-adc1-0242ac120002', 'La Mineure', 'Lilou',
            //     8, 'lilou.jesuisuneenfant@police.fr',
            //     '12345678', '36 30',
            //     null)
            // returning "idPersonne";
        }

// UPDATE

        public static void UpdatePersonne(PersonneDAO Personne)
        {
            // Mettre a jour Personne dans la bdd
        }

// DELETE

        public static void DeletePersonne(string PersonneId)
        {
            // Supprimer Personne dans la bdd
        }
            
    }
}