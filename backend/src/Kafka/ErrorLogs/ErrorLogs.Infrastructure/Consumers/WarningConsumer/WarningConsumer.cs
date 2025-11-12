using ErrorLogs.Infrastructure.Services.MessageConsumerService;
using Microsoft.Extensions.Hosting;
using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Consumers.WarningConsumer
{
    public class WarningConsumer : BackgroundService, IWarningConsumer
    {
        private readonly IMessageConsumerService _messageConsumerService;
        
        public WarningConsumer(IMessageConsumerService messageConsumerService)
        {
            _messageConsumerService = messageConsumerService;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken) =>
            await StartWarningConsumerAsync(stoppingToken);

        public async Task<ICommandNotification> StartWarningConsumerAsync(CancellationToken ct = default) =>
            await _messageConsumerService.StartWarningConsumerAsync(ct);
    }
}