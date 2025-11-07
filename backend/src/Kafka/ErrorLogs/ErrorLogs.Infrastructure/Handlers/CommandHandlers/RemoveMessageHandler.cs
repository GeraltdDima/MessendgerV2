using ErrorLogs.Domain.Commands;
using ErrorLogs.Infrastructure.Services.MessageCollectionService;
using Shared.DataBase.Domain.Events.CommandNotifications;
using Shared.Domain.Events;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace ErrorLogs.Infrastructure.Handlers.CommandHandlers
{
    public class RemoveMessageHandler : ICommandHandler<RemoveMessageCommand>
    {
        private readonly IMessageCollectionService _messageCollectionService;

        public RemoveMessageHandler(IMessageCollectionService messageCollectionService)
        {
            _messageCollectionService = messageCollectionService;
        }

        public async Task<ICommandNotification> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
        {
            var notification = await _messageCollectionService.GetByIdAsync(request.Id);
            var message = notification.Value;

            if (message == null)
                return new DataRemovedFailed<Guid>(request.Id, DateTime.UtcNow);

            var result = await _messageCollectionService.RemoveAsync(message);

            return result;
        }
    }
}