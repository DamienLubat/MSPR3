namespace MSPR3.Model
{
    public class LanguageEntity
    {
        public int IDLanguage { get; set; }
        public string? LanguageDescription { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Languages(LanguageDescription) VALUES (@LanguageDescription)";
        }
        public string ReadEntity()
        {
            return "SELECT IDLanguage,LanguageDescription FROM Languages WHERE IDLanguage = @IDLanguage";
        }
        public string UpdateEntity()
        {
            return "UPDATE Languages SET LanguageDescription = @LanguageDescription WHERE IDLanguage = @IDLanguage";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Languages WHERE IDLanguage = @IDLanguage";
        }
    }
}
