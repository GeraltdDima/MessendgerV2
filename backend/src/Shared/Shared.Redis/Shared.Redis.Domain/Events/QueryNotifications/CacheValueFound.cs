using Shared.Domain.Events;

namespace Shared.Redis.Domain.Events.QueryNotifications
{
    public class CacheValueFound<TEntity> : IQueryNotification<TEntity>
    {
        public CacheValueFound(TEntity entity, DateTime foundAt)
        {
            Value = entity;
            FoundAt = foundAt;
        }
        
        public TEntity Value { get; set; }
        
        public DateTime FoundAt { get; set; }
    }
}