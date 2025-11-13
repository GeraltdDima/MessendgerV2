using ErrorLogs.Shared.Domain.Models.MessageRequest;
using Kafka.Shared.Infrastructure.Services.KafkaProducerService;

namespace ErrorLogs.Shared.Infrastructure.Services.MessageProducerService
{
    public interface IMessageProducerService : IKafkaProducerService<IMessageRequest>;
}