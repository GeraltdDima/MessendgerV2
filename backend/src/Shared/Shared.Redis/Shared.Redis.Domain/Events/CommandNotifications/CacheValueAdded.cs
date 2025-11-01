using Shared.Domain.Events;

namespace Shared.Redis.Domain.Events.CommandNotifications
{
    public record CacheValueAdded
    (
        string ValueJson,
        DateTime AddedAt
    ) : ICommandNotification;
}