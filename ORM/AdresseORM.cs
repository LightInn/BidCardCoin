using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAL;
using bidCardCoin.DAO;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class AdresseORM
    {
        public static Adresse getUtilisateurById(string id)
        {
            AdresseDAO adao = AdresseDAL.SelectAdresseById(id);
            Adresse adresse = new Adresse(adao.IdAdresse, adao.Pays, adao.Region, adao.Ville, adao.CodePostal,
                adao.Adresse);

            return adresse;
        }
    }
}