using ErrorLogs.Infrastructure.Services.MessageConsumerService;
using Microsoft.Extensions.Hosting;
using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Consumers.InformationConsumer
{
    public class InformationConsumer : BackgroundService, IInformationConsumer
    {
        private readonly IMessageConsumerService _messageConsumerService;

        public InformationConsumer(IMessageConsumerService messageConsumerService)
        {
            _messageConsumerService = messageConsumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) =>
            await StartInformationConsumerAsync(stoppingToken);

        public async Task<ICommandNotification> StartInformationConsumerAsync(CancellationToken ct) =>
            await _messageConsumerService.StartInformationConsumerAsync(ct);
    }
}