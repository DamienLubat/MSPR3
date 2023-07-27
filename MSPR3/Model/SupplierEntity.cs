namespace MSPR3.Model
{
    public class SupplierEntity
    {
        public int IDSupplier { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Suppliers(Name, Adress, Phone) VALUES (@Name, @Adress, @Phone)";
        }
        public string ReadEntity()
        {
            return "SELECT IDSupplier, Name, Adress, Phone FROM Suppliers WHERE IDSupplier = @IDSupplier";
        }
        public string UpdateEntity()
        {
            return "UPDATE Suppliers SET Name = @Name, Adress = @Adress, Phone = @Phone WHERE IDSupplier = @IDSupplier";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Suppliers WHERE IDSupplier = @IDSupplier";
        }
    }
}
