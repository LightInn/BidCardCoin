namespace bidCardCoin.DAO
{
    public class PhotoDAO
    {
        public PhotoDAO()
        {
        }

        public PhotoDAO(string idPhoto, string produitId, string fichierPhoto)
        {
            IdPhoto = idPhoto;
            ProduitId = produitId;
            FichierPhoto = fichierPhoto;
        }

        public string IdPhoto { get; }
        public string ProduitId { get; }
        public string FichierPhoto { get; }
    }
}