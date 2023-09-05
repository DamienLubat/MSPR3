namespace MSPR3.Model
{
    public class UserEntity
    {
        public int IDUser { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public string CreatedEntity()
        {
            return "INSERT INTO Users(Username, Password) VALUES (@Username, @Password)";
        }
        public string ReadEntity()
        {
            return "SELECT IDUser, Username, Password FROM Users WHERE IDUser = @IDUser";
        }
        public string UpdateEntity()
        {
            return "UPDATE Users SET Username = @Username, Password = @Password WHERE IDUser = @IDUser";
        }
        public string DeleteEntity()
        {
            return "DELETE FROM Users WHERE IDUser = @IDUser";
        }
    }
}
