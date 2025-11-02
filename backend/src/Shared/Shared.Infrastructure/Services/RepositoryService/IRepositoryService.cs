using Shared.Domain.Models;
using Shared.Infrastructure.Repositories.Repository;

namespace Shared.Infrastructure.Services.RepositoryService
{
    public interface IRepositoryService<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>;
}