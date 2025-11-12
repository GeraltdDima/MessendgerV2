using Kafka.Domain.Commands;
using MediatR;
using Shared.Domain.Events;

namespace Kafka.Infrastructure.Services.KafkaConsumerService
{
    public class KafkaConsumerService<TData> : IKafkaConsumerService<TData>
    {
        private readonly IMediator _mediator;
        
        public KafkaConsumerService(IMediator mediator) => _mediator = mediator;

        public async Task<ICommandNotification> StartKafkaConsumer(string topic, Func<TData, Task> predicate,
            CancellationToken ct = default) =>
            await _mediator.Send(new StartKafkaConsumerCommand<TData>(topic, predicate, ct));
    }
}