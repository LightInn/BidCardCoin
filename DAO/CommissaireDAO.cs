using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class CommissaireDAO
    {
        public string IdCommissaire { get; }
        public string PersonneId { get; }

        public CommissaireDAO()
        {
        }

        public CommissaireDAO(string idCommissaire, string personneId)
        {
            this.IdCommissaire = idCommissaire;
            this.PersonneId = personneId;
        }

    }
}
