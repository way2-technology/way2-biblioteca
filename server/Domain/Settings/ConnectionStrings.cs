using Domain.Interfaces.Settings;

namespace Domain.Settings
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string SqlAzure { get; set; }
    }
}