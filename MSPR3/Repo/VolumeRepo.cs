using MSPR3.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MSPR3.Repo
{
    public class VolumeRepo
    {
        private readonly string configurationString;

        public VolumeRepo(IConfiguration configuration) => configurationString = configuration.GetConnectionString("SQL");

        public void Created(VolumeEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.CreatedEntity(), model);
            };
        }
        public VolumeEntity Read(int IDVolume)
        {
            VolumeEntity model = new VolumeEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                return db.QueryFirstOrDefault<VolumeEntity>(model.ReadEntity(), new { IDVolume = IDVolume });
            };
        }
        public void Update(VolumeEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.UpdateEntity(), model);
            };
        }
        public void Delete(int IDVolume)
        {
            VolumeEntity model = new VolumeEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.QueryFirstOrDefault<VolumeEntity>(model.DeleteEntity(), new { IDVolume = IDVolume });
            };
        }
    }
}
