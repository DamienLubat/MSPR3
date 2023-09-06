using System.ComponentModel;

namespace MSPR3.Model
{
    /// <summary>
    /// Classe de l'entité Item
    /// </summary>
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

        /// <summary>
        /// Constructeur Items
        /// </summary>
        /// <param name="IDItem"></param>
        /// <param name="GTIN"></param>
        /// <param name="DescriptionShort"></param>
        /// <param name="Price"></param>
        /// <param name="MediaPath"></param>
        public ItemEntity(int IDItem, string GTIN, string DescriptionShort, decimal Price, string MediaPath)
        {
            this.IDItem = IDItem;
            this.GTIN = GTIN;
            this.DescriptionShort = DescriptionShort;
            this.Price = Price;
            this.MediaPath = MediaPath;
        }
        /// <summary>
        /// Constructeur Items
        /// </summary>
        /// <param name="IDItem"></param>
        /// <param name="IDSupplier"></param>
        /// <param name="Name"></param>
        /// <param name="KeywordDescription"></param>
        public ItemEntity(int IDItem, int IDSupplier, string Name, string KeywordDescription)
        {
            this.IDItem = IDItem;
            this.IDSupplier = IDSupplier;
            this.Name = Name;
            this.KeywordDescription = KeywordDescription;
        }

        public ItemEntity() { }

        /// <summary>
        /// Requête sql de création
        /// </summary>
        /// <returns></returns>
        public string CreatedEntity()
        {
            return "INSERT INTO Items (GTIN, ItemWeigth, SaleUnite, IDMedia, IDLanguage, IDDescriptive, IDSupplier, IDPrice, IDTax, IDVolume) VALUES (@GTIN, @ItemWeigth, @SaleUnite, @IDMedia, @IDLanguage, @IDDescriptive, @IDSupplier, @IDPrice, @IDTax, @IDVolume)";
        }
        /// <summary>
        /// Requête sql de lecture
        /// </summary>
        /// <returns></returns>
        public string ReadEntity()
        {
            return "SELECT IDItem, GTIN, ItemWeigth, SaleUnite, IDMedia, IDLanguage, IDDescriptive, IDSupplier, IDPrice, IDTax, IDVolume FROM Items WHERE IDItem = @IDItem";
        }
        /// <summary>
        /// Requête sql de modification
        /// </summary>
        /// <returns></returns>
        public string UpdateEntity()
        {
            return "UPDATE Items SET GTIN = @GTIN, ItemWeigth = @ItemWeigth, SaleUnite = @SaleUnite, IDMedia = @IDMedia, IDLanguage = @IDLanguage, IDDescripti= @IDDescriptive, IDSupplier = @IDSupplier, IDPrice = @IDPrice, IDTax = @IDTax, IDVolume = @IDVolume WHERE IDItem = @IDItem";
        }
        /// <summary>
        /// Requête sql de suppression
        /// </summary>
        /// <returns></returns>
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
