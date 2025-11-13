using Shared.Domain.Events;

namespace Kafka.Shared.Domain.Events.CommandNotifications
{
    public record DataProduced<TData>(TData ProducedData, DateTime ProducedAt) : ICommandNotification;
}