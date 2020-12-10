using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class LotDAO
    {
        // todo attention géré le cas de la vente plusieurs fois et le don à l'association
        public string IdLot { get; }
        public string NomLot { get; }
        public string Description { get; }

        public LotDAO()
        {
        }

        public LotDAO(string idLot, string nomLot, string description)
        {
            this.IdLot = idLot;
            this.NomLot = nomLot;
            this.Description = description;
        }
    }
}
