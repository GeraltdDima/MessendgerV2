using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Postgres.Infrastructure.Factories.PostgreSQLSettingsFactory;

namespace Shared.Postgres.Core.Extensions.ServiceCollectionExtensions
{
    public static class PostgreSqLExtensions
    {
        public static IServiceCollection UsePostgreSql<TContext>
        (
            this IServiceCollection services,
            IPostgreSqLSettingsFactory psqlSettingsFactory
        ) where TContext : DbContext
        {
            var settings = psqlSettingsFactory.GetConfig();

            if (settings == null)
                throw new Exception("PostgreSQL settings not found");

            services.AddDbContext<TContext>(options =>
            {
                options.UseNpgsql(settings.ConnectionString);
            });
            
            return services;
        }
    }
}