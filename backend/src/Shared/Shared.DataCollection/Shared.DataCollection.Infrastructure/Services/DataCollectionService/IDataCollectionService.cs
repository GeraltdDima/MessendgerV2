using Shared.DataCollection.Domain.Models;
using Shared.Domain.Models;
using Shared.Infrastructure.Services.RepositoryService;

namespace Shared.DataCollection.Infrastructure.Services.DataCollectionService
{
    public interface IDataCollectionService<TEntity, TId> : IRepositoryService<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>;
}