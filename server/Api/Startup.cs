using Api.AppStart;
using Entities.Settings;
using IoC.Resolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api {
    public partial class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            ConfigureLoggerFactory(loggerFactory);
            app.ConfigureCors(env);
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
            app.ConfigureSwagger();
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny", policy =>
                {
                    policy.WithOrigins("https://w2lib.azurewebsites.net/").AllowAnyMethod();
                });
            });
            services.ConfigureSwagger();
            services.AddMvc();
            AddservicesAuthentication(services);
            services.ConfigureServices(Configuration["ConnectionStrings:SqlAzure"]);
        }
    }
}