using MSPR3.Model;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MSPR3.Repo
{
    public class ItemRepo
    {
        private readonly string configurationString;

        public ItemRepo(IConfiguration configuration) => configurationString = configuration.GetConnectionString("SQL");

        public void Created(ItemEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.CreatedEntity(), model);
            };
        }
        public ItemEntity Read(int IDItem)
        {
            ItemEntity model = new ItemEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                return db.QueryFirstOrDefault<ItemEntity>(model.ReadEntity(), new { IDItem = IDItem });
            };
        }
        public void Update(ItemEntity model)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                db.Execute(model.UpdateEntity(), model);
            };
        }
        public void Delete(int IDItem)
        {
            ItemEntity model = new ItemEntity();
            using (IDbConnection db = new SqlConnection(configurationString))
            {
               db.QueryFirstOrDefault<ItemEntity>(model.DeleteEntity(), new { IDItem = IDItem });
            };
        }

        public List<ItemEntity> ReadListCard()
        {
            List<ItemEntity> listItem = new List<ItemEntity>();
            ItemEntity model = new ItemEntity();
            var oSqlConnection = new SqlConnection(configurationString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(model.ReadCardEntity(), oSqlConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                listItem.Add(new ItemEntity
                {
                    IDItem = (int)row["IDITEM"],
                    GTIN = (string)row["GTIN"],
                    DescriptionShort = (string)row["DESCRIPTIONSHORT"],
                    Price = (decimal)row["PRICEHT"],
                    MediaPath = (string)row["MEDIAPATH"]
                });
            }

            return listItem;
        }

        public bool CheckIfItemExistsByGTIN(string GTIN)
        {
            using (IDbConnection db = new SqlConnection(configurationString))
            {
                var result = db.ExecuteScalar<int>("SELECT COUNT(*) FROM Items WHERE GTIN = @GTIN", new { GTIN = GTIN });
                return result > 0;
            };
        }

        public List<ItemEntity> GetItemsBySupplierAndKeyword(string Name, string KeywordDescription)
        {
            List<ItemEntity> listItem = new List<ItemEntity>();
            ItemEntity model = new ItemEntity();
            var oSqlConnection = new SqlConnection(configurationString);
            DataTable dataTable = new DataTable();

            using (var command = new SqlCommand(model.GetItemsBySupplierAndKeyword(), oSqlConnection))
            {
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@KeywordDescription", KeywordDescription);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dataTable);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                listItem.Add(new ItemEntity
                {
                    IDItem = (int)row["IDITEM"],
                    IDSupplier = (int)row["IDSupplier"],
                    Name = (string)row["Name"],
                    KeywordDescription = (string)row["KeywordDescription"]
                });
            }

            return listItem;
        }
    }
}
