using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using MSPR3.Model;
using System.Data;

namespace MSPR3.Repo
{
    // Classe représentant un utilisateur
    public class UserRepo
    {
        private readonly string configurationString;
        private readonly string configurationEncode;
        public UserRepo(IConfiguration configuration)
        {
            configurationEncode = configuration.GetConnectionString("KEY");
            configurationString = configuration.GetConnectionString("SQL");
        }
        public int IDUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Méthode pour ajouter un nouvel utilisateur
        public void Created(UserEntity user)
        {
            // Crypter le mot de passe avant de le stocker en base de données
            user.Password = ProtectPassword(user.Password);

            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@Username, @Password)", (SqlConnection)db);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.ExecuteNonQuery();
            }
        }

        // Méthode pour récupérer un utilisateur par son ID
        public UserEntity Read(int userID)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE IDUser = @IDUser", (SqlConnection)db);
                command.Parameters.AddWithValue("@IDUser", userID);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UserEntity user = new UserEntity
                    {
                        IDUser = (int)reader["IDUser"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"]
                    };
                    return user;
                }

                return null;
            }
        }

        // Méthode pour mettre à jour un utilisateur
        public void Update(UserEntity user)
        {
            // Crypter le mot de passe avant de le mettre à jour en base de données
            user.Password = ProtectPassword(user.Password);

            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Open();
                SqlCommand command = new SqlCommand("UPDATE Users SET Username = @Username, Password = @Password WHERE IDUser = @IDUser", (SqlConnection)db);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@IDUser", user.IDUser);
                command.ExecuteNonQuery();
            }
        }

        // Méthode pour supprimer un utilisateur
        public void Delete(int userID)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Users WHERE IDUser = @IDUser", (SqlConnection)db);
                command.Parameters.AddWithValue("@IDUser", userID);
                command.ExecuteNonQuery();
            }
        }

        // Méthode pour vérifier les informations de connexion de l'utilisateur
        public string AuthenticateUserOld(UserEntity user)
        {
            // Vérifier les informations de connexion dans la base de données
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Username = @Username", (SqlConnection)db);
                command.Parameters.AddWithValue("@Username", user.Username);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Comparer le mot de passe saisi avec le mot de passe crypté stocké en base de données
                    string storedPassword = (string)reader["Password"];
                    string enteredPassword = ProtectPassword(user.Password);

                    if (storedPassword == enteredPassword)
                    {
                        // Générer un token JWT pour l'utilisateur
                        UserEntity userAuth = new UserEntity
                        {
                            IDUser = (int)reader["IDUser"],
                            Username = (string)reader["Username"],
                            Password = storedPassword
                        };
                        return GenerateToken(userAuth);
                    }
                }

                return null;
            }
        }

        string ProtectPassword(string clearPassword)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(clearPassword);
            byte[] protectedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(protectedBytes);
        }

        private string GenerateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configurationEncode);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.IDUser.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string AuthenticateUser(UserEntity user)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Username = @Username", (SqlConnection)db);
                command.Parameters.AddWithValue("@Username", user.Username);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // Décodez le mot de passe stocké en Base64
                    byte[] decodedPassword = Convert.FromBase64String(user.Password);
                    string decodedPasswordString = Encoding.UTF8.GetString(decodedPassword);

                    if (user.Password == decodedPasswordString)
                    {
                        // Générer un token JWT pour l'utilisateur
                        UserEntity userAuth = new UserEntity
                        {
                            IDUser = (int)reader["IDUser"],
                            Username = (string)reader["Username"],
                            Password = decodedPasswordString
                        };
                        return GenerateToken(userAuth);
                    }
                }

                return null;
            }
        }

    }
}
