using Shared.Domain.Events;

namespace Kafka.Domain.Events.CommandNotifications
{
    public record KafkaConsumerFinished() : ICommandNotification;
}