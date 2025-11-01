using Shared.Domain.Events;

namespace Shared.Redis.Domain.Events.CommandNotifications
{
    public record CacheValueRemoved
    (
        string Key,
        DateTime RemovedAt
    ) : ICommandNotification;
}