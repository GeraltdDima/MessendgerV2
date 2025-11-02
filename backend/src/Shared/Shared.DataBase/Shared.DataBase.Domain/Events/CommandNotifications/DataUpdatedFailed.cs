using Shared.Domain.Events;

namespace Shared.DataBase.Domain.Events.CommandNotifications
{
    public record DataUpdatedFailed<TId>(
        TId FailedDataId,
        DateTime FailedAt
    ) : ICommandNotification;
}