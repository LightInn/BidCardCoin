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

        private bool _enStock;

        private Categorie _categorie;
        private string _photo;

        public Produit(string idProduit, Utilisateur utilisateur, Enchere enchereGagnante,
            string nomArtiste, string nomStyle, string nomProduit, double prixReserve, string referenceCatalogue,
            string description, bool enStock, string photo, Lot lot, Stock stock, Categorie categorie1)
        {
            this._idProduit = idProduit;
            _utilisateur = utilisateur;
            _enchereGagnante = enchereGagnante;
            this._nomArtiste = nomArtiste;
            this._nomStyle = nomStyle;
            this._nomProduit = nomProduit;
            this._prixReserve = prixReserve;
            this._referenceCatalogue = referenceCatalogue;
            this._description = description;
            this._enStock = enStock;
            this._photo = photo;
            _lot = lot;
            _stock = stock;
            _categorie = categorie1;
        }
    }
}