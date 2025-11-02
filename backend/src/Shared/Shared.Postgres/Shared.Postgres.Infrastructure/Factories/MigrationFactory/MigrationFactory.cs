using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Postgres.Infrastructure.Factories.MigrationFactory
{
    public class MigrationFactory : IMigrationFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MigrationFactory(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider;

        public async Task MigrateAsync<TContext>(string title = "DbContext") where TContext : DbContext
        {
            using var scope = _serviceProvider.CreateScope();
            
            var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();
            
            await dbContext.Database.MigrateAsync();
        }
    }
}