using Data.Helpers;
using Data.Interfaces.Helpers;
using Data.Interfaces.Repositories;
using Data.Interfaces.Settings;
using Data.Repositories;
using Data.Settings;
using Entities.Interfaces.Settings;
using Entities.Settings;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces.Features.Auth;
using Services.Interfaces.Features.Search;
using Services.Features.AuthServices;
using Services.Features.Search;
using Services.Features.Settings;
using Services.Features.BorrowBook;
using Services.Interfaces.Features.BorrowBook;

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
            services.AddScoped<IBookBorrowService, BookBorrowService>();
            services.AddScoped<IBookBorrowRepository, BookBorrowRepository>();
            services.AddScoped<IEmailConfirmationService, EmailConfirmationService>();
            services.AddSingleton<IConnectionStringsServices, ConnectionStringsServices>(serviceProvider =>
            {
                return new ConnectionStringsServices(new ConnectionStrings() { SqlAzure = connectionString });
            });

        }
    }
}