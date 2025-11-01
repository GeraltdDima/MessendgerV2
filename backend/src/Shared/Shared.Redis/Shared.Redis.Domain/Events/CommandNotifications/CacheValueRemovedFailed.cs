namespace Shared.Redis.Domain.Events.CommandNotifications
{
    public record CacheValueRemovedFailed
    (
        string Key,
        DateTime FailedAt
    );
}