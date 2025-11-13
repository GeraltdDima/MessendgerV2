using Shared.Domain.Events;

namespace Kafka.Shared.Domain.Events.CommandNotifications
{
    public record DataProducedFailed(DateTime FailedAt) : ICommandNotification;
}