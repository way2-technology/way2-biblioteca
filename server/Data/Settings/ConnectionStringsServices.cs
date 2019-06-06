using Data.Interfaces.Settings;
namespace Data.Settings {
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