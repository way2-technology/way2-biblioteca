using Domain.Interfaces.Settings;
using Domain.Settings;
namespace Domain.Services.Settings
{
    public class ConnectionStringsServices : IConnectionStringsServices
    {
        private readonly IConnectionStrings _connectionStrings;

        public ConnectionStringsServices(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public string SqlAzure => _connectionStrings.SqlAzure;
    }
}