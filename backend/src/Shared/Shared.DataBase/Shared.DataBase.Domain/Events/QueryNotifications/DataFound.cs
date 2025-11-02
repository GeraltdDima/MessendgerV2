using Shared.Domain.Events;

namespace Shared.DataBase.Domain.Events.QueryNotifications
{
    public class DataFound<TData> : IQueryNotification<TData?>
    {
        public DataFound(TData? data, DateTime foundAt)
        {
            Value = data;
            FoundAt = foundAt;
        }
        
        public TData? Value { get; set; }
        public DateTime FoundAt { get; set; }
    }
}