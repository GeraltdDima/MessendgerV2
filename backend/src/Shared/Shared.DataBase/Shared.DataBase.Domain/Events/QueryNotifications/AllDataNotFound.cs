using Shared.Domain.Events;

namespace Shared.DataBase.Domain.Events.QueryNotifications
{
    public class AllDataNotFound<TData> : IQueryNotification<IQueryable<TData>>
    {
        public AllDataNotFound(IQueryable<TData> data, DateTime foundAt)
        {
            Value = data;
            NotFoundAt = foundAt;
        }
        
        public IQueryable<TData> Value { get; set; }
        
        public DateTime NotFoundAt { get; set; }
    }
}