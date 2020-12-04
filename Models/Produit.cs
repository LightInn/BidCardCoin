using System.Windows.Ink;

namespace BidCardCoin.Models
{
    public class Produit
    {
        private string _idProduit;
        private Lot _lot;
        private Utilisateur _utilisateur;
        private Stock _stock;
        private Enchere _enchereGagnante;
        private string _nomArtiste;
        private string _nomStyle;
        private string _nomProduit;
        private double _prixReserve;
        private string _referenceCatalogue;
        private string _description;
        private Categorie _categorie;
        private string _photo;
        private bool _isSend;

        public Produit(string idProduit, Lot lot, Utilisateur utilisateur, Stock stock, Enchere enchereGagnante, string nomArtiste, 
            string nomStyle, string nomProduit, double prixReserve, string referenceCatalogue, string description, Categorie categorie, string photo, bool isSend)
        {
            this._idProduit = idProduit;
            this._lot = lot;
            this._utilisateur = utilisateur;
            this._stock = stock;
            this._enchereGagnante = enchereGagnante;
            this._nomArtiste = nomArtiste;
            this._nomStyle = nomStyle;
            this._nomProduit = nomProduit;
            this._prixReserve = prixReserve;
            this._referenceCatalogue = referenceCatalogue;
            this._description = description;
            this._categorie = categorie;
            this._photo = photo;
            this._isSend = isSend;
        }
    }
}