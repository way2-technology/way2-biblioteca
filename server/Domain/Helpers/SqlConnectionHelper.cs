using Dapper;
using Domain.Interfaces.Helpers;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domain.Helpers
{
    public class SqlConnectionHelper : ISqlConnectionHelper
    {
        public SqlConnection CreateNewConnection()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "way2libdbserver.database.windows.net",
                UserID = "way2lib",
                Password = "YT8Hfwd!",
                InitialCatalog = "way2librarydb",
            };

            return new SqlConnection(builder.ConnectionString);
        }

        public IEnumerable<T> Query<T>(string sql, object @params = null)
        {
            using (var connection = CreateNewConnection())
            {
                return connection.Query<T>(sql, @params);
            }
        }
    }
}