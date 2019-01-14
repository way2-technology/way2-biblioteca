using Domain.Interfaces.Factories;
using System.Data.SqlClient;

namespace Domain.Factories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public SqlConnection CreateNewConnection()
        {
            var builder = new SqlConnectionStringBuilder {
                DataSource = "***",
                UserID = "***",
                Password = "***",
                InitialCatalog = "***",
            };

            return new SqlConnection(builder.ConnectionString);
        }
    }
}