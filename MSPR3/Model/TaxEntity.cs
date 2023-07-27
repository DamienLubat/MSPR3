namespace MSPR3.Model
{
    public class TaxEntity
    {
        public int IDTax { get; set; }
        public float Rate { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Taxs(Rate) VALUES (@Rate)";
        }
        public string ReadEntity()
        {
            return "SELECT IDTax,Rate FROM Taxs WHERE IDTax = @IDTax";
        }
        public string UpdateEntity()
        {
            return "UPDATE Taxs SET Rate = @Rate WHERE IDTax = @IDTax";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Taxs WHERE IDTax = @IDTax";
        }
    }
}
