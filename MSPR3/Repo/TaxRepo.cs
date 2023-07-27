using MSPR3.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MSPR3.Repo
{
    public class TaxRepo
    {
        private readonly string configurationString;

        public TaxRepo(IConfiguration configuration) => configurationString = configuration.GetConnectionString("SQL");

        public void Created(TaxEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.CreatedEntity(), model);
            };
        }
        public TaxEntity Read(int IDTax)
        {
            TaxEntity model = new TaxEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                return db.QueryFirstOrDefault<TaxEntity>(model.ReadEntity(), new { IDTax = IDTax });
            };
        }
        public void Update(TaxEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.UpdateEntity(), model);
            };
        }
        public void Delete(int IDTax)
        {
            TaxEntity model = new TaxEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.QueryFirstOrDefault<TaxEntity>(model.DeleteEntity(), new { IDTax = IDTax });
            };
        }
    }
}
