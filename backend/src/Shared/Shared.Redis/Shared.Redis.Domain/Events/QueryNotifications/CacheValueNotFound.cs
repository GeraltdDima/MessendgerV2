using Shared.Domain.Events;

namespace Shared.Redis.Domain.Events.QueryNotifications
{
    public class CacheValueNotFound<TEntity> : IQueryNotification<TEntity>
    {
        public CacheValueNotFound(TEntity entity, DateTime notFoundAt)
        {
            Value = entity;
            NotFoundAt = notFoundAt;
        }
        
        public TEntity Value { get; set; }
        
        public DateTime NotFoundAt { get; set; }
    }
}