using Shared.Domain.Events;

namespace Shared.Redis.Domain.Events.CommandNotifications
{
    public record CacheValueAddedFailed
    (
        string FailedJson,
        DateTime FailedAt
    ) : ICommandNotification;
}