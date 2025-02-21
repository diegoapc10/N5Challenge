using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace N5ChallengeAPI.Extensions
{
    public static class ContextServices
    {
        public static void ConfigureDataBaseConnection(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<N5challengeContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
