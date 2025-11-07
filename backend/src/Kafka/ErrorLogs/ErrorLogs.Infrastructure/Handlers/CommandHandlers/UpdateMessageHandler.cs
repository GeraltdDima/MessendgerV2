using ErrorLogs.Domain.Commands;
using ErrorLogs.Infrastructure.Factories.MessageFactory;
using ErrorLogs.Infrastructure.Services.MessageCollectionService;
using Shared.Domain.Events;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace ErrorLogs.Infrastructure.Handlers.CommandHandlers
{
    public class UpdateMessageHandler : ICommandHandler<UpdateMessageCommand>
    {
        private readonly IMessageCollectionService _messageCollectionService;
        private readonly IMessageFactory _messageFactory;

        public UpdateMessageHandler(IMessageCollectionService messageCollectionService, IMessageFactory messageFactory)
        {
            _messageCollectionService = messageCollectionService;
            _messageFactory = messageFactory;
        }

        public async Task<ICommandNotification> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = _messageFactory.Create(request.Dto);
            
            var result = await _messageCollectionService.UpdateAsync(request.Id, message);
            
            return result;
        }
    }
}