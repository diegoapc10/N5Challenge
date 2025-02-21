using Serilog;

namespace N5ChallengeAPI.Extensions
{
    public static class SeriLogServices
    {
        public static void ConfigureSeriLog(this IServiceCollection services, string pathLog)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(pathLog, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
