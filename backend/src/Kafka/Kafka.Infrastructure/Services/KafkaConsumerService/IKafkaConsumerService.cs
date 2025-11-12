using Shared.Domain.Events;

namespace Kafka.Infrastructure.Services.KafkaConsumerService
{
    public interface IKafkaConsumerService<TData>
    {
        Task<ICommandNotification> StartKafkaConsumer(string topic, Func<TData, Task> predicate, CancellationToken ct = default);
    }
}