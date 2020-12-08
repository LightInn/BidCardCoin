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
        private string _idLot;
        private string _nomLot;
        private string _description;

        public LotDAO(string idLot, string nomLot, string description)
        {
            this._idLot = idLot;
            this._nomLot = nomLot;
            this._description = description;
        }
    }
}
