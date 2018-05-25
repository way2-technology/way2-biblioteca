using Microsoft.Extensions.Logging;

namespace Api
{
    public partial class Startup
    {
        private void ConfigureLoggerFactory(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
        }
    }
}