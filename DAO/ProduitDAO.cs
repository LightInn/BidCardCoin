using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bidCardCoin.DAO
{
    public class ProduitDAO
    {
        private string _idProduit;
        private string _nomArtiste;
        private string _nomStyle;
        private string _nomProduit;
        private double _prixReserve;
        private string _referenceCatalogue;
        private string _descriptionProduit;
        private bool _isSend;
        
        private string _stockId;
        private string _utilisateurId;
        private string _lotId;
        private string _enchereGagnanteId;

        // Sans enchere gagnante
        public ProduitDAO(string idProduit, string nomArtiste, string nomStyle, string nomProduit, double prixReserve, string referenceCatalogue, string descriptionProduit, bool isSend, string stockId, string utilisateurId, string lotId)
        {
            _idProduit = idProduit;
            _nomArtiste = nomArtiste;
            _nomStyle = nomStyle;
            _nomProduit = nomProduit;
            _prixReserve = prixReserve;
            _referenceCatalogue = referenceCatalogue;
            _descriptionProduit = descriptionProduit;
            _isSend = isSend;
            _stockId = stockId;
            _utilisateurId = utilisateurId;
            _lotId = lotId;
        }
        
        // Avec une enchere gagnante 
        public ProduitDAO(string idProduit, string nomArtiste, string nomStyle, string nomProduit, double prixReserve, string referenceCatalogue, string descriptionProduit, bool isSend, string stockId, string utilisateurId, string lotId, string enchereGagnanteId)
        {
            _idProduit = idProduit;
            _nomArtiste = nomArtiste;
            _nomStyle = nomStyle;
            _nomProduit = nomProduit;
            _prixReserve = prixReserve;
            _referenceCatalogue = referenceCatalogue;
            _descriptionProduit = descriptionProduit;
            _isSend = isSend;
            _stockId = stockId;
            _utilisateurId = utilisateurId;
            _lotId = lotId;
            _enchereGagnanteId = enchereGagnanteId;
        }
    }
}
