using Serilog;

namespace VersionManager.Configurations
{
    public static class SerilogConfiguration
    {
        public static void ConfigureSerilog(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();

            var logger = Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .WriteTo.Console()
                .WriteTo.File(
                    path: Path.Combine(AppContext.BaseDirectory, "logs", "log_.txt"),
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog(logger);
        }
    }
}
