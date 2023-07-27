using MSPR3.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MSPR3.Repo
{
    public class MediaRepo
    {
        private readonly string configurationString;

        public MediaRepo(IConfiguration configuration) => configurationString = configuration.GetConnectionString("SQL");

        public void Created(MediaEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.CreatedEntity(), model);
            };
        }
        public MediaEntity Read(int IDMedia)
        {
            MediaEntity model = new MediaEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                return db.QueryFirstOrDefault<MediaEntity>(model.ReadEntity(), new { IDMedia = IDMedia });
            };
        }
        public void Update(MediaEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.UpdateEntity(), model);
            };
        }
        public void Delete(int IDMedia)
        {
            MediaEntity model = new MediaEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.QueryFirstOrDefault<MediaEntity>(model.DeleteEntity(), new { IDMedia = IDMedia });
            };
        }
    }
}
