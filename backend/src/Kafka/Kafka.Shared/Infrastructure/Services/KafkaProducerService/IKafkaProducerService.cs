using Shared.Domain.Events;

namespace Kafka.Shared.Infrastructure.Services.KafkaProducerService
{
    public interface IKafkaProducerService<TData>
    {
        Task<ICommandNotification> ProduceDataAsync(string topic, TData data);
    }
}