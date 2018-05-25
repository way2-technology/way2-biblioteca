using Domain.Interfaces.Settings;

namespace Domain.Settings
{
    public class AppSettings : IAppSettings
    {
        public string Secret { get; set; }
    }
}