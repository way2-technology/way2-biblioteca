using Data.Interfaces.Settings;

namespace Data.Settings
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string SqlAzure { get; set; }
    }
}