using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Factories.MigrationFactory;

namespace Shared.Infrastructure.Services.DataBaseService
{
    public class DataBaseService : IDataBaseService
    {
        private readonly IMigrationFactory _migrationFactory;

        public DataBaseService(IMigrationFactory migrationFactory)
        {
            _migrationFactory = migrationFactory;
        }

        public async Task MigrateAsync<TContext>(string title = "DbContext") where TContext : DbContext =>
            await _migrationFactory.MigrateAsync<TContext>(title);
    }
}