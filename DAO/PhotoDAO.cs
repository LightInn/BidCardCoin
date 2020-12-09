using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class PhotoDAO
    {
        private string _idPhoto;
        // todo Liens vers les images , mettre les images dans un fichier particulier par ici ? et le transformer en base / blob / binaire / jsais pas quoi ?
        private string _fichierPhoto;
        private string _produitId;

        public PhotoDAO()
        {
        }

        public PhotoDAO(string idPhoto, string fichierPhoto, string produitId)
        {
            this._idPhoto = idPhoto;
            this._fichierPhoto = fichierPhoto;
            this._produitId = produitId;
        }
    }
}
