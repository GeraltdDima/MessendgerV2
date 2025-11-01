using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Redis.Domain.Events.CommandNotifications;
using Shared.Redis.Domain.Events.QueryNotifications;

namespace Shared.Redis.Infrastructure.Repositories.RedisRepository
{
    public class RedisRepository<TEntity, TId> : IRedisRepository<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IDistributedCache _cache;

        public RedisRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<ICommandNotification> AddAsync(TEntity entity, TimeSpan expiration, CancellationToken ct = default)
        {
            var json = JsonSerializer.Serialize(entity);

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            await _cache.SetStringAsync(entity.GetString(), json, options, ct);

            return new CacheValueAdded(json, DateTime.UtcNow);
        }

        public async Task<ICommandNotification> RemoveAsync(TEntity entity, CancellationToken ct = default)
        {
            await _cache.RemoveAsync(entity.GetString(), ct);
            
            return new CacheValueRemoved(entity.GetString(), DateTime.UtcNow);
        }

        public async Task<ICommandNotification> RemoveByKeyAsync(string key, CancellationToken ct = default)
        {
            await _cache.RemoveAsync(key, ct);

            return new CacheValueRemoved(key, DateTime.UtcNow);
        }

        public async Task<IQueryNotification<TEntity?>> GetByIdAsync(string id)
        {
            var json = await _cache.GetStringAsync(id);
            var entity = JsonSerializer.Deserialize<TEntity?>(json ?? string.Empty);

            if (entity == null)
                return new CacheValueNotFound<TEntity?>(entity, DateTime.UtcNow);
            
            return new CacheValueFound<TEntity?>(entity, DateTime.UtcNow);
        }
    }
}