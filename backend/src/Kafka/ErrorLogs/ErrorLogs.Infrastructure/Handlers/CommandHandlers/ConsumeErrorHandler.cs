using ErrorLogs.Domain.Commands;
using ErrorLogs.Shared.Domain.Models.MessageRequest;
using ErrorLogs.Infrastructure.Factories.MessageDtoFactory;
using ErrorLogs.Infrastructure.Services.MessageService;
using ErrorLogs.Shared.Domain.Singleton;
using Kafka.Infrastructure.Services.KafkaConsumerService;
using Microsoft.Extensions.Logging;
using Shared.Domain.Events;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace ErrorLogs.Infrastructure.Handlers.CommandHandlers
{
    public class ConsumeErrorHandler : ICommandHandler<ConsumeErrorCommand>
    {
        private readonly IMessageService _messageService;
        private readonly IMessageDtoFactory _messageDtoFactory;
        
        private readonly IKafkaConsumerService<IMessageRequest>  _messageConsumer;
        
        private readonly ILogger<ConsumeErrorHandler> _logger;

        public ConsumeErrorHandler(IMessageService messageService, IMessageDtoFactory messageDtoFactory, IKafkaConsumerService<IMessageRequest> messageConsumer, ILogger<ConsumeErrorHandler> logger)
        {
            _messageService = messageService;
            _messageDtoFactory = messageDtoFactory;
            _logger = logger;
            _messageConsumer = messageConsumer;
        }

        public async Task<ICommandNotification> Handle(ConsumeErrorCommand request, CancellationToken cancellationToken)
        {
            var result = await _messageConsumer.StartKafkaConsumer
            (
                MessageTopics.ErrorLogs,
                message => HandleErrorAsync(message),
                request.Ct
            );

            return result;
        }

        public async Task HandleErrorAsync(IMessageRequest messageRequest)
        {
            _logger.LogError($"Error occured: {messageRequest.Info}");

            var message = _messageDtoFactory.Create(messageRequest);

            await _messageService.AddAsync(message);
        }
    }
}