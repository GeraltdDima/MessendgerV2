using ErrorLogs.Shared.Domain.Models.MessageRequest;
using ErrorLogs.Shared.Domain.Singleton;
using ErrorLogs.Shared.Infrastructure.Services.MessageProducerService;
using Microsoft.AspNetCore.Http;
using Shared.DataBase.Domain.Events.CommandNotifications;
using Shared.Infrastructure.Handlers.NotificationHandlers;

namespace Shared.DataBase.Infrastructure.Handlers.NotificationHandlers.CommandNotificationHandlers
{
    public class DataUpdatedFailedHandler<TId> : ICommandNotificationHandler<DataUpdatedFailed<TId>>
    {
        private readonly IMessageProducerService _messageProducerService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataUpdatedFailedHandler(IMessageProducerService messageProducerService,
            IHttpContextAccessor httpContextAccessor)
        {
            _messageProducerService = messageProducerService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(DataUpdatedFailed<TId> notification, CancellationToken cancellationToken)
        {
            string idString = notification.FailedDataId.ToString() ?? string.Empty;
            
            var error = new ErrorRequest
            (
                $"Data updated failed!Time: {notification.FailedAt}.Failed to update: {idString}",
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