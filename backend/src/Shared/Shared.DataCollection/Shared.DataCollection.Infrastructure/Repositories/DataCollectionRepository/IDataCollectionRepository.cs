using Shared.DataCollection.Domain.Models;
using Shared.Domain.Models;
using Shared.Infrastructure.Repositories.Repository;

namespace Shared.DataCollection.Infrastructure.Repositories.DataCollectionRepository
{
    public interface IDataCollectionRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>;
}