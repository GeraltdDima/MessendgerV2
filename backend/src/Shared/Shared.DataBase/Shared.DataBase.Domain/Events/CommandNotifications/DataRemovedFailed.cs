using Shared.Domain.Events;

namespace Shared.DataBase.Domain.Events.CommandNotifications
{
    public record DataRemovedFailed<TId>(TId DataId, DateTime FailedAt) : ICommandNotification;
}