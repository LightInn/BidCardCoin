namespace bidCardCoin.DAO
{
    public class LotDAO
    {
        public LotDAO()
        {
        }

        public LotDAO(string idLot, string nomLot, string description)
        {
            IdLot = idLot;
            NomLot = nomLot;
            Description = description;
        }

        // todo attention géré le cas de la vente plusieurs fois et le don à l'association
        public string IdLot { get; }
        public string NomLot { get; }
        public string Description { get; }
    }
}