using MSPR3.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MSPR3.Repo
{
    public class SupplierRepo
    {
        private readonly string configurationString;

        public SupplierRepo(IConfiguration configuration) => configurationString = configuration.GetConnectionString("SQL");

        public void Created(SupplierEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.CreatedEntity(), model);
            };
        }
        public SupplierEntity Read(int IDSupplier)
        {
            SupplierEntity model = new SupplierEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                return db.QueryFirstOrDefault<SupplierEntity>(model.ReadEntity(), new { IDSupplier = IDSupplier });
            };
        }
        public void Update(SupplierEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.UpdateEntity(), model);
            };
        }
        public void Delete(int IDSupplier)
        {
            SupplierEntity model = new SupplierEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.QueryFirstOrDefault<SupplierEntity>(model.DeleteEntity(), new { IDSupplier = IDSupplier });
            };
        }
    }
}
