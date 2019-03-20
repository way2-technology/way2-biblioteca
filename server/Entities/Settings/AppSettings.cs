using Entities.Interfaces.Settings;

namespace Entities.Settings
{
    public class AppSettings : IAppSettings
    {
        public string Secret { get; set; }
    }
}