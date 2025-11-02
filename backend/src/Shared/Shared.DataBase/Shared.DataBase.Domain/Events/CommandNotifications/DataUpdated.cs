using Shared.Domain.Events;

namespace Shared.DataBase.Domain.Events.CommandNotifications
{
    public record DataUpdated<TData>(
        TData UpdatedData,
        DateTime UpdatedAt
    ) : ICommandNotification;
}