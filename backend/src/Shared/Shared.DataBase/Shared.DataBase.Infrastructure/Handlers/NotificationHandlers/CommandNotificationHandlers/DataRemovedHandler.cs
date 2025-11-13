using System.Text.Json;
using ErrorLogs.Shared.Domain.Models.MessageRequest;
using ErrorLogs.Shared.Domain.Singleton;
using ErrorLogs.Shared.Infrastructure.Services.MessageProducerService;
using Microsoft.AspNetCore.Http;
using Shared.DataBase.Domain.Events.CommandNotifications;
using Shared.Infrastructure.Handlers.NotificationHandlers;

namespace Shared.DataBase.Infrastructure.Handlers.NotificationHandlers.CommandNotificationHandlers
{
    public class DataRemovedHandler<TData> : ICommandNotificationHandler<DataRemoved<TData>>
    {
        private readonly IMessageProducerService _messageProducerService;
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataRemovedHandler(IMessageProducerService messageProducerService,
            IHttpContextAccessor httpContextAccessor)
        {
            _messageProducerService = messageProducerService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(DataRemoved<TData> notification, CancellationToken cancellationToken)
        {
            string json = JsonSerializer.Serialize(notification.RemovedData);

            var information = new InformationRequest
            (
                $"Data removed successfully!Time: {notification.RemovedAt}.Removed data: {json}",
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