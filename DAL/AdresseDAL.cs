using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
     public static class AdresseDAL
    {
// SELECT

        public static AdresseDAO SelectAdresseById(string id)
        {
            // Selectionné l'adresse a partir de l'id
            return new AdresseDAO();
        }


        public static List<AdresseDAO> SelectAllAdresse()
        {
            // Selectionné tout les adresse dans la base de donnée
            return new List<AdresseDAO>();
        }


// INSERT

        public static void InsertNewAdresse(AdresseDAO adresse)
        {
            // Inserer adresse dans la bdd
        }

// UPDATE

        public static void UpdateAdresse(AdresseDAO adresse)
        {
            // Mettre a jour adresse dans la bdd
        }

// DELETE

        public static void DeleteAdresse(string adresseId)
        {
            // Supprimer adresse dans la bdd
        }
    }
}