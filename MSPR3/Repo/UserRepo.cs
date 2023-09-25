using Microsoft.Data.SqlClient;
using System.Data;
using MSPR3.Entity;
using Dapper;

namespace MSPR3.Repo
{
    // Classe représentant un utilisateur
    public class UserRepo
    {
        private readonly IConfiguration? _configuration;

        public UserRepo(IConfiguration? configuration)
        {
            _configuration = configuration;
        }

        public UserEntity GetById(int id)
        {
            var oEntity = new UserEntity();
            var oSqlConnection = new SqlConnection(_configuration?.GetConnectionString("SQL"));

            var aEntity = oSqlConnection.Query<UserEntity>(oEntity.ReadString("Id"),
                new { Id = id }).ToList();
            aEntity.ForEach(o => oEntity = o);

            oSqlConnection.Close();
            return (oEntity.Username == null && oEntity.PasswordHash == null) ? null : oEntity;
        }
        public UserEntity GetByUsername(string usernanme)
        {
            var oEntity = new UserEntity();
            var oSqlConnection = new SqlConnection(_configuration?.GetConnectionString("SQL"));

            var aEntity = oSqlConnection.Query<UserEntity>(oEntity.ReadString("Username"),
                new { Username = usernanme }).ToList();
            aEntity.ForEach(o => oEntity = o);

            oSqlConnection.Close();
            return (oEntity.Username == null && oEntity.PasswordHash == null) ? null : oEntity;
        }

        public bool Update(UserEntity oEntity)
        {
            try
            {
                var oSqlConnection = new SqlConnection(_configuration?.GetConnectionString("SQL"));
                var oSqlParam1 = new SqlParameter("@IdUser", oEntity.IDUser);
                var oSqlParam2 = new SqlParameter("@Username", oEntity.Username);
                var oSqlParam3 = new SqlParameter("@PasswordHash", BCrypt.Net.BCrypt.HashPassword(oEntity.PasswordHash));
                var oSqlCommand = new SqlCommand(oEntity.UpdateString());

                oSqlCommand.Parameters.AddRange(new SqlParameter[] { oSqlParam1, oSqlParam2, oSqlParam3 });

                oSqlCommand.Connection = oSqlConnection;
                oSqlConnection.Open();

                oSqlCommand.ExecuteNonQuery();
                oSqlConnection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                UserEntity oEntity = new UserEntity();
                var oSqlConnection = new SqlConnection(_configuration?.GetConnectionString("SQL"));
                var oSqlParam = new SqlParameter("@IDUser", Id);
                var oSqlCommand = new SqlCommand(oEntity.DeleteString(), oSqlConnection);
                oSqlCommand.Parameters.Add(oSqlParam);

                oSqlConnection.Open();

                oSqlCommand.ExecuteNonQuery();
                oSqlConnection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Insert(UserEntity oEntity)
        {
            if (GetByUsername(oEntity.Username) == null)
            {
                var oSqlConnection = new SqlConnection(_configuration?.GetConnectionString("SQL"));
                var oSqlParam1 = new SqlParameter("@Username", oEntity.Username);
                var oSqlParam2 = new SqlParameter("@PasswordHash", BCrypt.Net.BCrypt.HashPassword(oEntity.PasswordHash));
                oSqlConnection.Open();
                var oSqlTransaction = oSqlConnection.BeginTransaction();
                try
                {
                    var oSqlCommand = new SqlCommand(oEntity.CreateString(), oSqlConnection, oSqlTransaction);

                    oSqlCommand.Parameters.AddRange(new SqlParameter[] { oSqlParam1, oSqlParam2 });

                    oSqlTransaction.Commit();
                    return Convert.ToInt32(oSqlCommand.ExecuteScalar());
                }
                catch (Exception)
                {
                    oSqlTransaction.Rollback();
                    return -1;
                }
                finally
                {
                    oSqlConnection.Close();
                }
            }
            else
            {
                throw new Exception("Utilisateur déjà existant.");
            }
        }

        public List<UserEntity> Getall()
        {
            UserEntity oEntity = new UserEntity();
            var oListEntity = new List<UserEntity>();
            var oSqlConnection = new SqlConnection(_configuration?.GetConnectionString("SQL"));
            SqlDataAdapter dataAdapter = new SqlDataAdapter(oEntity.GetAllString(), oSqlConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                oListEntity.Add(new UserEntity
                {
                    IDUser = (int)row["IDUser"],
                    Username = (string)row["USERNAME"],
                    PasswordHash = (string)row["PASSWORDHASH"]
                });
            }

            return oListEntity;
        }

        public string Login(UserEntity oEntity)
        {
            Model.Tools.JwtHandler jwtHandler = new Model.Tools.JwtHandler(_configuration.GetSection("JwtSettings")["SecretKey"]);
            string? token = null;
            var user = GetByUsername(oEntity.Username);

            if (user == null)
            {
                throw new Exception("Utilisateur introuvable.");
            }
            else
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(oEntity.PasswordHash, user.PasswordHash);

                if (!isPasswordValid)
                {
                    throw new Exception("Mot de passe incorrect.");
                }

                token = jwtHandler.GenerateToken(user.IDUser.ToString(), user.Username);
            }

            return token;
        }

    }
}
