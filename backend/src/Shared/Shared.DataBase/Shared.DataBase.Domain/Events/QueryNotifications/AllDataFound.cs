using Shared.Domain.Events;

namespace Shared.DataBase.Domain.Events.QueryNotifications
{
    public class AllDataFound<TData> : IQueryNotification<IQueryable<TData>>
    {
        public AllDataFound(IQueryable<TData> data, DateTime foundAt)
        {
            Value = data;
            FoundAt = foundAt;
        }
        public IQueryable<TData> Value { get; set; }
        
        public DateTime FoundAt { get; set; }
    }
}