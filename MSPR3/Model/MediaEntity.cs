namespace MSPR3.Model
{
    public class MediaEntity
    {
        public int IDMedia { get; set; }
        public string? MediaPath { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Medias(MediaPath) VALUES (@MediaPath)";
        }
        public string ReadEntity()
        {
            return "SELECT IDMedia,MediaPath FROM Medias WHERE IDMedia = @IDMedia";
        }
        public string UpdateEntity()
        {
            return "UPDATE Medias SET MediaPath = @MediaPath WHERE IDMedia = @IDMedia";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Medias WHERE IDMedia = @IDMedia";
        }
    }
}
