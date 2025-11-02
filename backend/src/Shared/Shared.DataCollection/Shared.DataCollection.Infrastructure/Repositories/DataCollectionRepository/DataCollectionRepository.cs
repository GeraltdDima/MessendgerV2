using Shared.DataBase.Domain.Events.QueryNotifications;
using Shared.DataBase.Infrastructure.Services.DataBaseService;
using Shared.DataCollection.Domain.Models;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Redis.Infrastructure.Services.CacheService;

namespace Shared.DataCollection.Infrastructure.Repositories.DataCollectionRepository
{
    public class DataCollectionRepository<TEntity, TId, TCollection> :
        IDataCollectionRepository<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>
        where TCollection : IDataCollection<TEntity, TId>, IBaseEntity<TCollection, TId>
    {
        private readonly IDataBaseService<TEntity, TId> _dbService;
        
        private readonly ICacheService<TEntity, TId> _cache;
        private readonly ICacheService<TCollection, TId> _collectionCache;
        
        public DataCollectionRepository
        (
            IDataBaseService<TEntity, TId> dbService,
            ICacheService<TEntity, TId> cache, 
            ICacheService<TCollection, TId> collectionCache
        )
        {
            _dbService = dbService;
            _cache = cache;
            _collectionCache = collectionCache;
        }

        private string CurrentCollectionString { get; set; } = string.Empty;
        
        private IIdStringBuilder<TId> IdStringBuilder { get; set; } = new IdStringBuilder<TId>();

        public void SetIdStringBuilder(IIdStringBuilder<TId> idStringBuilder)
        {
            IdStringBuilder = idStringBuilder;
        }

        public async Task<ICommandNotification> AddAsync(TEntity entity)
        {
            var result = await _dbService.AddAsync(entity);
            await _cache.AddAsync(entity, TimeSpan.FromMinutes(3));

            await InvalidateCollectionAsync();

            return result;
        }

        public async Task<ICommandNotification> RemoveAsync(TEntity entity)
        {
            var result = await _dbService.RemoveAsync(entity);
            await _cache.RemoveAsync(entity);
            
            await InvalidateCollectionAsync();

            return result;
        }

        public async Task<ICommandNotification> UpdateAsync(TId id, TEntity entity)
        {
            var result = await _dbService.UpdateAsync(id, entity);
            await _cache.RemoveByKeyAsync(IdStringBuilder.GetString(id));

            await _cache.AddAsync(entity, TimeSpan.FromMinutes(3));
            
            await InvalidateCollectionAsync();

            return result;
        }

        public async Task<IQueryNotification<TEntity?>> GetByIdAsync(TId id)
        {
            var cachedEntity = await _cache.GetByIdAsync(IdStringBuilder.GetString(id));
            
            if (cachedEntity.Value != null)
                return new DataFound<TEntity>(cachedEntity.Value, DateTime.UtcNow);
            
            var dbEntity = await _dbService.GetByIdAsync(id);
            
            return dbEntity;
        }

        public async Task<IQueryNotification<IQueryable<TEntity>>> GetAllAsync()
        {
            if (string.IsNullOrWhiteSpace(CurrentCollectionString))
            {
                var dbEntities = await _dbService.GetAllAsync();
                
                var collection = (TCollection)Activator.CreateInstance(typeof(TCollection), dbEntities.Value)!;

                var collectionKey = ((IDataCollection<TEntity, TId>)collection).GetString();
                
                CurrentCollectionString = collectionKey;

                await _collectionCache.AddAsync(collection, TimeSpan.FromMinutes(10));

                return dbEntities;
            }

            var cachedCollection = await _collectionCache.GetByIdAsync(CurrentCollectionString);
            
            if (cachedCollection.Value == null)
                return new AllDataNotFound<TEntity>(Enumerable.Empty<TEntity>().AsQueryable(), DateTime.UtcNow);

            return new AllDataFound<TEntity>(cachedCollection.Value.Entities, DateTime.UtcNow);
        }
        
        private async Task InvalidateCollectionAsync()
        {
            if (string.IsNullOrWhiteSpace(CurrentCollectionString))
                return;
            
            await _collectionCache.RemoveByKeyAsync(CurrentCollectionString);
            CurrentCollectionString = string.Empty;
        }
    }
}