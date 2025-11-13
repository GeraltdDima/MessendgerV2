using System.Text.Json;
using Confluent.Kafka;
using Kafka.Shared.Domain.Commands;
using Kafka.Shared.Domain.Events.CommandNotifications;
using Shared.Domain.Events;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace Kafka.Shared.Infrastructure.Handlers.CommandHandlers
{
    public class ProduceDataHandler<TData> : ICommandHandler<ProduceDataCommand<TData>>
    {
        private readonly IProducer<string, string>  _producer;

        public ProduceDataHandler(IProducer<string, string> producer)
        {
            _producer = producer;
        }

        public async Task<ICommandNotification> Handle(ProduceDataCommand<TData> request, CancellationToken cancellationToken)
        {
            string json = JsonSerializer.Serialize(request.Data);

            if (string.IsNullOrEmpty(json))
                return new DataProducedFailed(DateTime.UtcNow);

            await _producer.ProduceAsync(request.Topic, new Message<string, string>()
            {
                Key = Guid.NewGuid().ToString(),
                Value = json
            });

            return new DataProduced<TData>(request.Data, DateTime.UtcNow);
        }
    }
}