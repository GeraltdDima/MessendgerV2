using ErrorLogs.Infrastructure.Services.MessageConsumerService;
using Microsoft.Extensions.Hosting;
using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Consumers.ErrorConsumer
{
    public class ErrorConsumer : BackgroundService, IErrorConsumer
    {
        private readonly IMessageConsumerService _messageConsumerService;

        public ErrorConsumer(IMessageConsumerService messageConsumerService)
        {
            _messageConsumerService = messageConsumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) =>
            await StartErrorConsumerAsync(stoppingToken);

        public async Task<ICommandNotification> StartErrorConsumerAsync(CancellationToken ct = default) =>
            await _messageConsumerService.StartErrorConsumerAsync(ct);
    }
}