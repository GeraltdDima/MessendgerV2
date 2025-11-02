using Shared.Domain.Events;

namespace Shared.DataBase.Domain.Events.CommandNotifications
{
    public record DataAdded<TData>
    (
        TData AddedData,
        DateTime AddedAt
    ) : ICommandNotification;
}