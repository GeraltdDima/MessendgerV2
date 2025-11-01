using Shared.Domain.Events;
using Shared.Domain.Models;

namespace Shared.Redis.Infrastructure.Repositories.RedisRepository
{
    public interface IRedisRepository<TEntity, TId> where TEntity : IBaseEntity<TEntity, TId>
    {
        Task<ICommandNotification> AddAsync(TEntity entity, TimeSpan expiration, CancellationToken ct = default);
        
        Task<ICommandNotification> RemoveAsync(TEntity entity, CancellationToken ct = default);

        Task<ICommandNotification> RemoveByKeyAsync(string key, CancellationToken ct = default);

        Task<IQueryNotification<TEntity?>> GetByIdAsync(string id);
    }
}