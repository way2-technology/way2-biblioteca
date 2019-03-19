using Dapper;
using Domain.Interfaces.Helpers;
using Domain.Services.Settings;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domain.Helpers
{
    public class SqlConnectionHelper : ISqlConnectionHelper
    {
        private IConnectionStringsServices _connectionStringsServices;
        public SqlConnectionHelper(IConnectionStringsServices connectionStringsServices)
        {
            _connectionStringsServices = connectionStringsServices;
        }
        public SqlConnection CreateNewConnection() =>
            new SqlConnection(_connectionStringsServices.SqlAzure);
        

        public IEnumerable<T> Query<T>(string sql, object @params = null)
        {
            var connection = CreateNewConnection();
            try
            {
                return connection.Query<T>(sql, @params);
            }
            finally {
                connection.Close();
            }
        }
    }
}