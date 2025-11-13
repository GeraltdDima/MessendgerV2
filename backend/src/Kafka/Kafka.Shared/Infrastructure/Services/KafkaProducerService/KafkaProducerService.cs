using Kafka.Shared.Domain.Commands;
using MediatR;
using Shared.Domain.Events;

namespace Kafka.Shared.Infrastructure.Services.KafkaProducerService
{
    public class KafkaProducerService<TData> : IKafkaProducerService<TData>
    {
        private readonly IMediator _mediator;
        
        public KafkaProducerService(IMediator mediator) => _mediator = mediator;

        public virtual async Task<ICommandNotification> ProduceDataAsync(string topic, TData data) =>
            await _mediator.Send(new ProduceDataCommand<TData>(topic, data));
    }
}