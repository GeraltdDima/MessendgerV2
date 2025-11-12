using System.Text.Json;
using Confluent.Kafka;
using Kafka.Domain.Commands;
using Kafka.Domain.Events.CommandNotifications;
using Shared.Domain.Events;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace Kafka.Infrastructure.Handlers.CommandHandlers
{
    public class StartKafkaConsumerHandler<TData> : ICommandHandler<StartKafkaConsumerCommand<TData>>
    {
        private readonly IConsumer<string, string> _consumer;

        public StartKafkaConsumerHandler(IConsumer<string, string> consumer)
        {
            _consumer = consumer;
        }

        public async Task<ICommandNotification> Handle(StartKafkaConsumerCommand<TData> request, CancellationToken cancellationToken)
        {
            _consumer.Subscribe(request.Topic);

            while (!request.Ct.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume(request.Ct);

                if (consumeResult == null)
                    continue;
                
                var data = JsonSerializer.Deserialize<TData>(consumeResult.Message.Value);

                if (data == null)
                    continue;

                await request.Predicate(data);
            }

            return new KafkaConsumerFinished();
        }
    }
}