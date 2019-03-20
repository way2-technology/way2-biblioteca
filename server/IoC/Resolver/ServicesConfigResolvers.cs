using Domain.Helpers;
using Domain.Interfaces.Helpers;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services.Auth;
using Domain.Interfaces.Services.Search;
using Domain.Interfaces.Settings;
using Domain.Repositories;
using Domain.Services.AuthServices;
using Domain.Services.Search;
using Domain.Services.Settings;
using Domain.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Resolver
{
    public static class ServicesConfigResolvers
    {
        public static void ConfigureServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAppSettings, AppSettings>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAppSettingsServices, AppSettingsServices>();
            services.AddScoped<IBookSearchService, BookSearchService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ISqlConnectionHelper, SqlConnectionHelper>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IConnectionStringsServices, ConnectionStringsServices>();
            services.AddSingleton<IConnectionStringsServices, ConnectionStringsServices>(serviceProvider => {
                return new ConnectionStringsServices(new ConnectionStrings() { SqlAzure = connectionString});
            });

        }
    }
}