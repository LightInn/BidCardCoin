using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAO;

namespace bidCardCoin.DAL
{
    public static class PhotoDAL
    {
        // SELECT

        public static PhotoDAO SelectPhotoById(string id)
        {
            // Selectionné l'Photo a partir de l'id
            return new PhotoDAO();
        }


        public static List<PhotoDAO> SelectAllPhoto()
        {
            // Selectionné tout les Photo dans la base de donnée
            return new List<PhotoDAO>();
        }


// INSERT

        public static void InsertNewPhoto(PhotoDAO Photo)
        {
            // Inserer Photo dans la bdd
        }

// UPDATE

        public static void UpdatePhoto(PhotoDAO Photo)
        {
            // Mettre a jour Photo dans la bdd
        }

// DELETE

        public static void DeletePhoto(string PhotoId)
        {
            // Supprimer Photo dans la bdd
        }
    }
}
