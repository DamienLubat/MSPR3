namespace MSPR3.Model
{
    public class DescriptiveEntity
    {
        public int IDDescriptive { get; set; }
        public int IDLanguage { get; set; }
        public string? DescriptionShort { get; set; }
        public string? DescriptionLong { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Descriptives(IDLanguage, DescriptionShort, DescriptionLong) VALUES (@IDLanguage, @DescriptionShort, @DescriptionLong)";
        }
        public string ReadEntity()
        {
            return "SELECT IDDescriptive, IDLanguage, DescriptionShort, DescriptionLong FROM Descriptives WHERE IDDescriptive = @IDDescriptive";
        }
        public string UpdateEntity()
        {
            return "UPDATE Descriptives SET IDLanguage = @IDLanguage, DescriptionShort = @DescriptionShort, DescriptionLong = @DescriptionLong WHERE IDDescriptive = @IDDescriptive";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Descriptives WHERE IDDescriptive = @IDDescriptive";
        }
    }
}
