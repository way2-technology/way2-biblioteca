using Domain.Interfaces.Settings;
using Domain.Settings;
using Microsoft.Extensions.Options;

namespace Domain.Services.Settings
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