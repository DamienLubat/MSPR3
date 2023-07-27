using MSPR3.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MSPR3.Repo
{
    public class PriceRepo
    {
        private readonly string configurationString;

        public PriceRepo(IConfiguration configuration) => configurationString = configuration.GetConnectionString("SQL");

        public void Created(PriceEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.CreatedEntity(), model);
            };
        }
        public PriceEntity Read(int IDPrice)
        {
            PriceEntity model = new PriceEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                return db.QueryFirstOrDefault<PriceEntity>(model.ReadEntity(), new { IDPrice = IDPrice });
            };
        }
        public void Update(PriceEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.UpdateEntity(), model);
            };
        }
        public void Delete(int IDPrice)
        {
            PriceEntity model = new PriceEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.QueryFirstOrDefault<PriceEntity>(model.DeleteEntity(), new { IDPrice = IDPrice });
            };
        }
    }
}
