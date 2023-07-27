namespace MSPR3.Model
{
    public class ItemEntity
    {
        public int IDItem { get; set; }
        public string GTIN { get; set; }
        public float ItemWeigth { get; set; }
        public int SaleUnite { get; set; }
        public int IDMedia { get; set; }
        public int IDLanguage { get; set; }
        public int IDDescriptive { get; set; }
        public int IDSupplier { get; set; }
        public int IDPrice { get; set; }
        public int IDTax { get; set; }
        public int IDVolume { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Items (GTIN, ItemWeigth, SaleUnite, IDMedia, IDLanguage, IDDescriptive, IDSupplier, IDPrice, IDTax, IDVolume) VALUES (@GTIN, @ItemWeigth, @SaleUnite, @IDMedia, @IDLanguage, @IDDescriptive, @IDSupplier, @IDPrice, @IDTax, @IDVolume)";
        }
        public string ReadEntity()
        {
            return "SELECT IDItem, GTIN, ItemWeigth, SaleUnite, IDMedia, IDLanguage, IDDescriptive, IDSupplier, IDPrice, IDTax, IDVolume FROM Items WHERE IDItem = @IDItem";
        }
        public string UpdateEntity()
        {
            return "UPDATE Items SET GTIN = @GTIN, ItemWeigth = @ItemWeigth, SaleUnite = @SaleUnite, IDMedia = @IDMedia, IDLanguage = @IDLanguage, IDDescripti= @IDDescriptive, IDSupplier = @IDSupplier, IDPrice = @IDPrice, IDTax = @IDTax, IDVolume = @IDVolume WHERE IDItem = @IDItem";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Items WHERE IDItem = @IDItem";
        }
        public string ReadCardEntity()
        {
            return "Select Items.GTIN, Descriptives.DescriptionShort, Prices.PriceHT, Medias.MediaPath " +
                "From Items Items " +
                "Inner Join Descriptives On Descriptives.IDDescriptive = Items.IDDescriptive " +
                "Inner Join Medias On Medias.IDMedia = Items.IDMedia " +
                "Inner Join Prices On Prices.IDPrice = Items.IDPrice ";
        }
    }
}
