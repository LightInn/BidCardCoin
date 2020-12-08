using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class CommissaireDAO
    {
        private string _idCommissaire;
        private string _personneId;

        public CommissaireDAO(string idCommissaire, string personneId)
        {
            this._idCommissaire = idCommissaire;
            this._personneId = personneId;
        }

    }
}
