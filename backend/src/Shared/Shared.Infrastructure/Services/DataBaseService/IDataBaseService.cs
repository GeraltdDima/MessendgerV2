using Microsoft.EntityFrameworkCore;

namespace Shared.Infrastructure.Services.DataBaseService
{
    public interface IDataBaseService
    {
        Task MigrateAsync<TContext>(string title = "DbContext") where TContext : DbContext;
    }
}