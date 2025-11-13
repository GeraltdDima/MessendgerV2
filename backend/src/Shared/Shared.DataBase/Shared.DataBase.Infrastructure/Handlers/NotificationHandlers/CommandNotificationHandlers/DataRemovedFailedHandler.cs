using ErrorLogs.Shared.Domain.Models.MessageRequest;
using ErrorLogs.Shared.Domain.Singleton;
using ErrorLogs.Shared.Infrastructure.Services.MessageProducerService;
using Microsoft.AspNetCore.Http;
using Shared.DataBase.Domain.Events.CommandNotifications;
using Shared.Infrastructure.Handlers.NotificationHandlers;

namespace Shared.DataBase.Infrastructure.Handlers.NotificationHandlers.CommandNotificationHandlers
{
    public class DataRemovedFailedHandler<TId> : ICommandNotificationHandler<DataRemovedFailed<TId>>
    {
        private readonly IMessageProducerService _messageProducerService;
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataRemovedFailedHandler(IMessageProducerService messageProducerService,
            IHttpContextAccessor httpContextAccessor)
        {
            _messageProducerService = messageProducerService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(DataRemovedFailed<TId> notification, CancellationToken cancellationToken)
        {
            string idString = notification.DataId.ToString() ?? string.Empty;
            
            var error = new ErrorRequest
            (
                $"Data removed failed!Time: {notification.FailedAt}.Failed to remove: {idString}",
                string.Empty,
                _httpContextAccessor.HttpContext.Request.Path
            );

            await _messageProducerService.ProduceDataAsync
            (
                MessageTopics.ErrorLogs,
                error
            );
        }
    }
}