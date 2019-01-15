using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domain.Interfaces.Helpers
{
    public interface ISqlConnectionHelper
    {
        SqlConnection CreateNewConnection();
        IEnumerable<T> Query<T>(string sql, object @params = null);
    }
}