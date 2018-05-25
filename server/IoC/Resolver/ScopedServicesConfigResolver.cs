using Domain.Interfaces.Services.Auth;
using Domain.Interfaces.Settings;
using Domain.Services.AuthServices;
using Domain.Services.Settings;
using Domain.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Resolver
{
    public static class ScopedServicesConfigResolvers
    {
        public static void ConfigureScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IAppSettings, AppSettings>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAppSettingsServices, AppSettingsServices>();
        }
    }
}