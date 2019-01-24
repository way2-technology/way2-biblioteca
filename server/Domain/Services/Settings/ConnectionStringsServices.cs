using Domain.Interfaces.Settings;
using Domain.Settings;
using Microsoft.Extensions.Options;

namespace Domain.Services.Settings
{
    public class ConnectionStringsServices : IConnectionStringsServices
    {
        private readonly IConnectionStrings _connectionStrings;

        public ConnectionStringsServices(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        public string SqlAzure => _connectionStrings.SqlAzure;
    }
}