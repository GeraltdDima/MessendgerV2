using Shared.Domain.Events;

namespace Shared.DataBase.Domain.Events.CommandNotifications
{
    public record DataRemoved<TData>(
        TData RemovedData,
        DateTime RemovedAt
    ) : ICommandNotification;
}