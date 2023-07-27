namespace MSPR3.Model
{
    public class PriceEntity
    {
        public int IDPrice { get; set; }
        public string? Currency { get; set; }
        public float PriceHT { get; set; }
        public int QuantityMin { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Prices(Currency, PriceHT, QuantityMin) VALUES (@Currency, @PriceHT, @QuantityMin)";
        }
        public string ReadEntity()
        {
            return "SELECT IDPrice, Currency, PriceHT, QuantityMin FROM Prices WHERE IDPrice = @IDPrice";
        }
        public string UpdateEntity()
        {
            return "UPDATE Prices SET Currency = @Currency, PriceHT = @PriceHT, QuantityMin = @QuantityMin WHERE IDPrice = @IDPrice";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Prices WHERE IDPrice = @IDPrice";
        }
    }
}
