using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class VenteDAL
    {
        // SELECT


        public static VenteDAO SelectVenteById(string id)

        {
            // Selectionné l'Vente a partir de l'id
            return new VenteDAO();
        }


        public static List<VenteDAO> SelectAllVente()
        {
            // Selectionné tout les Vente dans la base de donnée
            return new List<VenteDAO>();
        }


// INSERT

        public static void InsertNewVente(VenteDAO Vente)
        {
            // Inserer Vente dans la bdd
        }

// UPDATE

        public static void UpdateVente(VenteDAO Vente)
        {
            // Mettre a jour Vente dans la bdd
        }

// DELETE

        public static void DeleteVente(string VenteId)
        {
            // Supprimer Vente dans la bdd
        }
            
    }
}
