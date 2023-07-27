namespace MSPR3.Model
{
    public class KeywordEntity
    {
        public int IDKeyword { get; set; }
        public string? KeywordDescription { get; set; }
        public int IDItem { get; set; }
        public int IDMedia { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Keywords(KeywordDescription, IDItem, IDMedia) VALUES (@KeywordDescription, @IDItem, @IDMedia)";
        }
        public string ReadEntity()
        {
            return "SELECT IDKeyword, KeywordDescription, IDItem, IDMedia FROM Keywords WHERE IDKeyword = @IDKeyword";
        }
        public string UpdateEntity()
        {
            return "UPDATE Keywords SET KeywordDescription = @KeywordDescription, IDItem = @IDItem, IDMedia = @IDMedia WHERE IDKeyword = @IDKeyword";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Keywords WHERE IDKeyword = @IDKeyword";
        }
    }
}
