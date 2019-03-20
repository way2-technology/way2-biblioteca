using Entities.Interfaces.Settings;
using Entities.Settings;
using Microsoft.Extensions.Options;

namespace Services.Features.Settings
{
    public class AppSettingsServices : IAppSettingsServices
    {
        private readonly IAppSettings _appSettings;

        public AppSettingsServices(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string Secret { get => _appSettings.Secret; set => Secret = value; }
    }
}