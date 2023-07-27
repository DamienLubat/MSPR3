using MSPR3.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MSPR3.Repo
{
    public class LanguageRepo
    {
        private readonly string configurationString;

        public LanguageRepo(IConfiguration configuration) => configurationString = configuration.GetConnectionString("SQL");

        public void Created(LanguageEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.CreatedEntity(), model);
            };
        }
        public LanguageEntity Read(int IDLanguage)
        {
            LanguageEntity model = new LanguageEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                return db.QueryFirstOrDefault<LanguageEntity>(model.ReadEntity(), new { IDLanguage = IDLanguage });
            };
        }
        public void Update(LanguageEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.UpdateEntity(), model);
            };
        }
        public void Delete(int IDLanguage)
        {
            LanguageEntity model = new LanguageEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.QueryFirstOrDefault<LanguageEntity>(model.DeleteEntity(), new { IDLanguage = IDLanguage });
            };
        }
    }
}
