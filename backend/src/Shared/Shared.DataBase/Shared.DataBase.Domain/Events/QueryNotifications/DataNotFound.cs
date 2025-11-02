using Shared.Domain.Events;

namespace Shared.DataBase.Domain.Events.QueryNotifications
{
    public class DataNotFound<TData> : IQueryNotification<TData?>
    {
        public DataNotFound(TData? data, DateTime notFoundAt)
        {
            Value = data;
            NotFoundAt = notFoundAt;
        }
        
        public TData? Value { get; set; }
        
        public DateTime NotFoundAt { get; set; }
    }
}