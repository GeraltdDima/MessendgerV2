using ErrorLogs.Domain.Commands;
using ErrorLogs.Domain.Models.MessageRequest;
using ErrorLogs.Shared.Domain.Singleton;
using Kafka.Infrastructure.Services.KafkaConsumerService;
using Microsoft.Extensions.Logging;
using Shared.Domain.Events;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace ErrorLogs.Infrastructure.Handlers.CommandHandlers
{
    public class ConsumeInformationHandler : ICommandHandler<ConsumeInformationCommand>
    {
        private readonly IKafkaConsumerService<IMessageRequest> _messageConsumer;
        
        private readonly ILogger<ConsumeInformationHandler> _logger;

        public ConsumeInformationHandler(IKafkaConsumerService<IMessageRequest> messageConsumer, ILogger<ConsumeInformationHandler> logger)
        {
            _messageConsumer = messageConsumer;
            _logger = logger;
        }

        public async Task<ICommandNotification> Handle(ConsumeInformationCommand request, CancellationToken cancellationToken)
        {
            var result = await _messageConsumer.StartKafkaConsumer
            (
                MessageTopics.InformationLogs,
                message => HandleInformation(message),
                request.Ct
            );
            
            return result;
        }

        public Task HandleInformation(IMessageRequest messageRequest)
        {
            _logger.LogInformation(messageRequest.Info);
            
            return Task.CompletedTask;
        }
    }
}