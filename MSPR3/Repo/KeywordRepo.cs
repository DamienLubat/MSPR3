using MSPR3.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MSPR3.Repo
{
    public class KeywordRepo
    {
        private readonly string configurationString;

        public KeywordRepo(IConfiguration configuration) => configurationString = configuration.GetConnectionString("SQL");

        public void Created(KeywordEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.CreatedEntity(), model);
            };
        }
        public KeywordEntity Read(int IDKeyword)
        {
            KeywordEntity model = new KeywordEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                return db.QueryFirstOrDefault<KeywordEntity>(model.ReadEntity(), new { IDKeyword = IDKeyword });
            };
        }
        public void Update(KeywordEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.UpdateEntity(), model);
            };
        }
        public void Delete(int IDKeyword)
        {
            KeywordEntity model = new KeywordEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.QueryFirstOrDefault<KeywordEntity>(model.DeleteEntity(), new { IDKeyword = IDKeyword });
            };
        }
    }
}
