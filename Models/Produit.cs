using System.Windows.Ink;

namespace BidCardCoin.Models
{
    public class Produit
    {
        public string IdProduit { get; }
        public Lot LotProduit { get; set; }
        public Utilisateur UtilisateurProduit { get; set; }
        public Stock StockProduit { get; set; }
        public Enchere EnchereGagnante { get;  set; }
        public Categorie CategorieProduit { get;  set; }
        public string NomArtiste { get; }
        public string NomStyle { get; }
        public string NomProduit { get; }
        public double PrixReserve { get; }
        public string ReferenceCatalogue { get; }
        public string Description { get; }
        public string Photo { get; }
        public bool IsSend { get; }

        public Produit()
        {
            
        }
        public Produit(string idProduit, Lot lotProduit, Utilisateur utilisateurProduit, Stock stockProduit, Enchere enchereGagnante, Categorie categorieProduit, string nomArtiste, string nomStyle, string nomProduit, double prixReserve, string referenceCatalogue, string description, string photo, bool isSend)
        {
            IdProduit = idProduit;
            LotProduit = lotProduit;
            UtilisateurProduit = utilisateurProduit;
            StockProduit = stockProduit;
            EnchereGagnante = enchereGagnante;
            CategorieProduit = categorieProduit;
            NomArtiste = nomArtiste;
            NomStyle = nomStyle;
            NomProduit = nomProduit;
            PrixReserve = prixReserve;
            ReferenceCatalogue = referenceCatalogue;
            Description = description;
            Photo = photo;
            IsSend = isSend;
        }
    }
}