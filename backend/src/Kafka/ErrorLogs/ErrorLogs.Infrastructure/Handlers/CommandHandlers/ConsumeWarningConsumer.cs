using ErrorLogs.Domain.Commands;
using ErrorLogs.Domain.Models.MessageRequest;
using ErrorLogs.Shared.Domain.Singleton;
using Kafka.Infrastructure.Services.KafkaConsumerService;
using Microsoft.Extensions.Logging;
using Shared.Domain.Events;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace ErrorLogs.Infrastructure.Handlers.CommandHandlers
{
    public class ConsumeWarningConsumer : ICommandHandler<ConsumeWarningCommand>
    {
        private readonly IKafkaConsumerService<IMessageRequest> _messageConsumer;
        
        private readonly ILogger<ConsumeWarningConsumer> _logger;

        public ConsumeWarningConsumer(IKafkaConsumerService<IMessageRequest> messageConsumer, ILogger<ConsumeWarningConsumer> logger)
        {
            _messageConsumer = messageConsumer;
            _logger = logger;
        }

        public async Task<ICommandNotification> Handle(ConsumeWarningCommand request, CancellationToken cancellationToken)
        {
            var result = await _messageConsumer.StartKafkaConsumer
            (
                MessageTopics.WarningLogs,
                message => HandleWarning(message),
                request.Ct
            );

            return result;
        }

        public Task HandleWarning(IMessageRequest messageRequest)
        {
            _logger.LogWarning(messageRequest.Info);
            
            return Task.CompletedTask;
        }
    }
}