using ErrorLogs.Shared.Domain.Models.MessageRequest;
using Kafka.Shared.Infrastructure.Services.KafkaProducerService;
using MediatR;

namespace ErrorLogs.Shared.Infrastructure.Services.MessageProducerService
{
    public class MessageProducerService : KafkaProducerService<IMessageRequest>,
        IMessageProducerService
    {
        public MessageProducerService(IMediator mediator) : base(mediator) { }
    }
}