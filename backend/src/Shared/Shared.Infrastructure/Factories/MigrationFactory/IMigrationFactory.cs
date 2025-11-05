using Microsoft.EntityFrameworkCore;

namespace Shared.Infrastructure.Factories.MigrationFactory
{
    public interface IMigrationFactory
    {
        Task MigrateAsync<TContext>(string title = "DbContext") where TContext : DbContext;
    }
}