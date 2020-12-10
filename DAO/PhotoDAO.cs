using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class PhotoDAO
    {
        public string IdPhoto { get; }
        public string ProduitId { get; }
        public string FichierPhoto { get; }

        public PhotoDAO()
        {
        }

        public PhotoDAO(string idPhoto, string produitId,string fichierPhoto)
        {
            this.IdPhoto = idPhoto;
            this.ProduitId = produitId;
            this.FichierPhoto = fichierPhoto;
        }
    }
}
