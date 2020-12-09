using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class UtilisateurDAL
    {
        // SELECT

        public static UtilisateurDAO SelectUtilisateurById(string id)
        {
            // Selectionné l'Utilisateur a partir de l'id
            return new UtilisateurDAO();
        }


        public static List<UtilisateurDAO> SelectAllUtilisateur()
        {
            // Selectionné tout les Utilisateur dans la base de donnée
            return new List<UtilisateurDAO>();
        }


// INSERT

        public static void InsertNewUtilisateur(UtilisateurDAO Utilisateur)
        {
            // Inserer Utilisateur dans la bdd
        }

// UPDATE

        public static void UpdateUtilisateur(UtilisateurDAO Utilisateur)
        {
            // Mettre a jour Utilisateur dans la bdd
        }

// DELETE

        public static void DeleteUtilisateur(string UtilisateurId)
        {
            // Supprimer Utilisateur dans la bdd
        }
    }
}
