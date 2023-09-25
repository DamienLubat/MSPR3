namespace MSPR3.Entity
{
    public class UserEntity
    {
        public int IDUser { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public UserEntity() { }
        public UserEntity(int id, string username, string password)
        {
            IDUser = id;
            Username = username;
            PasswordHash = password;
        }

        public string CreateString()
        {
            return "Insert Into Users(USERNAME, PASSWORDHASH) Values (@Username, @PasswordHash); Select @@Identity;";
        }
        public string ReadString(string type)
        {
            var typeExtend = (type == "Id") ? "User" : "";
            return $"Select * From Users Where {type}{typeExtend} = @{type}";
        }
        public string UpdateString()
        {
            return "Update Users Set USERNAME = @Username, PASSWORDHASH = @PasswordHash Where IDUser = @IdUser";
        }
        public string DeleteString()
        {
            return "Delete Users Where IDUser = @IDUser";
        }
        public string GetAllString()
        {
            return "Select * From Users";
        }
    }
}
