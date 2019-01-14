using System.Data.SqlClient;

namespace Domain.Interfaces.Factories
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateNewConnection();
    }
}