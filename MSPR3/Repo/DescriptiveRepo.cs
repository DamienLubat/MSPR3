using MSPR3.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MSPR3.Repo
{
    public class DescriptiveRepo
    {
        private readonly string configurationString;

        public DescriptiveRepo(IConfiguration configuration) => configurationString = configuration.GetConnectionString("SQL");

        public void Created(DescriptiveEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.CreatedEntity(), model);
            };
        }
        public DescriptiveEntity Read(int IDDescriptive)
        {
            DescriptiveEntity model = new DescriptiveEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                return db.QueryFirstOrDefault<DescriptiveEntity>(model.ReadEntity(), new { IDDescriptive = IDDescriptive });
            };
        }
        public void Update(DescriptiveEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.UpdateEntity(), model);
            };
        }
        public void Delete(int IDDescriptive)
        {
            DescriptiveEntity model = new DescriptiveEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.QueryFirstOrDefault<DescriptiveEntity>(model.DeleteEntity(), new { IDDescriptive = IDDescriptive });
            };
        }
    }
}
