using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class OrdreAchatDAL
    {
        // SELECT


        public static OrdreAchatDAO SelectOrdreAchatById(string id)

        {
            // Selectionné l'OrdreAchat a partir de l'id
            return new OrdreAchatDAO();
        }


        public static List<OrdreAchatDAO> SelectAllOrdreAchat()
        {
            // Selectionné tout les OrdreAchat dans la base de donnée
            return new List<OrdreAchatDAO>();
        }


// INSERT

        public static void InsertNewOrdreAchat(OrdreAchatDAO OrdreAchat)
        {
            // Inserer OrdreAchat dans la bdd
        }

// UPDATE

        public static void UpdateOrdreAchat(OrdreAchatDAO OrdreAchat)
        {
            // Mettre a jour OrdreAchat dans la bdd
        }

// DELETE

        public static void DeleteOrdreAchat(string OrdreAchatId)
        {
            // Supprimer OrdreAchat dans la bdd
        }
        
    }
}
