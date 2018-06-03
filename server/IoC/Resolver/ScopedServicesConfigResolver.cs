using Domain.Interfaces;
using Domain.Interfaces.Services.Auth;
using Domain.Interfaces.Services.Search;
using Domain.Interfaces.Settings;
using Domain.Repositories;
using Domain.Services.AuthServices;
using Domain.Services.Search;
using Domain.Services.Settings;
using Domain.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Resolver
{
    public static class ScopedServicesConfigResolvers
    {
        public static void ConfigureScopedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAppSettings, AppSettings>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAppSettingsServices, AppSettingsServices>();
            services.AddScoped<IBookRepository, BookRepository>((_) => new BookRepository(configuration.GetSection("AppSettings")["JsonBookFilePath"]));
            services.AddScoped<IBookSearchService, BookSearchService>();
        }
    }
}