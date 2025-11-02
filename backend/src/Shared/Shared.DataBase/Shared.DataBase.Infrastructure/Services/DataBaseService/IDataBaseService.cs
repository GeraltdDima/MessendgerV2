using Shared.Domain.Models;
using Shared.Infrastructure.Services.RepositoryService;

namespace Shared.DataBase.Infrastructure.Services.DataBaseService
{
    public interface IDataBaseService<TEntity, TId> : IRepositoryService<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>;
}