using System.ComponentModel;

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

        public string? DescriptionShort { get; set; }
        public decimal Price { get; set; }
        public string? MediaPath { get; set; }

        public string? Name { get; set; }
        public string? KeywordDescription { get; set; }
        public ItemEntity(int IDItem, string GTIN, string DescriptionShort, decimal Price, string MediaPath)
        {
            this.IDItem = IDItem;
            this.GTIN = GTIN;
            this.DescriptionShort = DescriptionShort;
            this.Price = Price;
            this.MediaPath = MediaPath;
        }

        public ItemEntity(int IDItem, int IDSupplier, string Name, string KeywordDescription)
        {
            this.IDItem = IDItem;
            this.IDSupplier = IDSupplier;
            this.Name = Name;
            this.KeywordDescription = KeywordDescription;
        }

        public ItemEntity() { }

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
            return "Select Items.IDItem, Items.GTIN, Descriptives.DescriptionShort, Prices.PriceHT, Medias.MediaPath " +
                "From Items Items " +
                "Inner Join Descriptives On Descriptives.IDDescriptive = Items.IDDescriptive " +
                "Inner Join Medias On Medias.IDMedia = Items.IDMedia " +
                "Inner Join Prices On Prices.IDPrice = Items.IDPrice ";
        }
        public string ReadDetailEntity()
        {
            return "Select Items.IDItem, Items.GTIN, Descriptives.DescriptionShort, Prices.PriceHT, Medias.MediaPath " +
                "From Items Items " +
                "Inner Join Descriptives On Descriptives.IDDescriptive = Items.IDDescriptive " +
                "Inner Join Medias On Medias.IDMedia = Items.IDMedia " +
                "Inner Join Prices On Prices.IDPrice = Items.IDPrice " +
                "Where IDItem = @IDItem";
        }

        public string CheckIfItemExistsByGTINEntity()
        {
            return "SELECT 1 FROM Items WHERE GTIN = @GTIN";
        }

        public string GetItemsBySupplierAndKeyword()
        {
            return "SELECT * FROM Items\r\n" +
                "INNER JOIN Suppliers ON Items.IDSupplier = Suppliers.IDSupplier\r\n" +
                "INNER JOIN Keywords ON Items.IDItem = Keywords.IDItem\r\n" +
                "WHERE Suppliers.Name = @Name AND Keywords.KeywordDescription = @KeywordDescription";
        }
    }
}
