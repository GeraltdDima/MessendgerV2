using Shared.DataBase.Infrastructure.Services.DataBaseService;
using Shared.DataCollection.Domain.Models;
using Shared.Domain.Models;
using Shared.Redis.Infrastructure.Services.CacheService;

namespace Shared.DataCollection.Infrastructure.Repositories.DataCollectionRepository
{
    public abstract class DataCollectionRepository<TEntity, TId> :
        DataCollectionRepository<TEntity, TId, DataCollection<TEntity, TId>>,
        IDataCollectionRepository<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        public DataCollectionRepository
        (
            IDataBaseService<TEntity, TId> dbService,
            ICacheService<TEntity, TId> cache,
            ICacheService<DataCollection<TEntity, TId>, TId> collectionCache,
            IIdStringBuilder<TId> idStringBuilder
        ) : base(dbService, cache, collectionCache, idStringBuilder) { }
    }
}