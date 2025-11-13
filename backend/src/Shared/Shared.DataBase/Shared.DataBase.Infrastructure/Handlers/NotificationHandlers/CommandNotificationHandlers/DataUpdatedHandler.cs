using System.Text.Json;
using ErrorLogs.Shared.Domain.Models.MessageRequest;
using ErrorLogs.Shared.Domain.Singleton;
using ErrorLogs.Shared.Infrastructure.Services.MessageProducerService;
using Microsoft.AspNetCore.Http;
using Shared.DataBase.Domain.Events.CommandNotifications;
using Shared.Infrastructure.Handlers.NotificationHandlers;

namespace Shared.DataBase.Infrastructure.Handlers.NotificationHandlers.CommandNotificationHandlers
{
    public class DataUpdatedHandler<TData> : ICommandNotificationHandler<DataUpdated<TData>>
    {
        private readonly IMessageProducerService _messageProducerService;
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataUpdatedHandler(IMessageProducerService messageProducerService,
            IHttpContextAccessor httpContextAccessor)
        {
            _messageProducerService = messageProducerService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(DataUpdated<TData> notification, CancellationToken cancellationToken)
        {
            string json = JsonSerializer.Serialize(notification.UpdatedData);

            var information = new InformationRequest
            (
                $"Data updated successfully!Time: {notification.UpdatedAt}.Data: {json}",
                string.Empty,
                _httpContextAccessor.HttpContext.Request.Path
            );

            await _messageProducerService.ProduceDataAsync
            (
                MessageTopics.InformationLogs,
                information
            );
        }
    }
}