using Api.AppStart;
using Domain.Settings;
using IoC.Resolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ConfigureLoggerFactory(loggerFactory);
            app.ConfigureCors(env);
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
            app.ConfigureSwagger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.ConfigureSwagger();
            services.AddMvc();
            AddservicesAuthentication(services);
            services.ConfigureScopedServices(Configuration);
        }
    }
}