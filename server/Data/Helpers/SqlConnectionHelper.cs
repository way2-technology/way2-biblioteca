using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Data.Interfaces.Helpers;
using Data.Interfaces.Settings;

namespace Data.Helpers {
    public class SqlConnectionHelper : ISqlConnectionHelper
    {
        private readonly IConnectionStringsServices _connectionStringsServices;
        public SqlConnectionHelper(IConnectionStringsServices connectionStringsServices)
        {
            _connectionStringsServices = connectionStringsServices;
        }

        public int Count(string table, string condition) {
            condition = !string.IsNullOrEmpty(condition) ? $"where {condition}" : string.Empty;
            var sql = $"select count(1) as quantidade from {table} {condition}";
            var connection = CreateNewConnection();
            try {
                return connection.QuerySingle(sql).quantidade;
            }
            finally {
                connection.Close();
            }
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