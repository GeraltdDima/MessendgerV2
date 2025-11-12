using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Services.MessageConsumerService
{
    public interface IMessageConsumerService
    {
        Task<ICommandNotification> StartErrorConsumerAsync(CancellationToken ct = default);
        
        Task<ICommandNotification> StartWarningConsumerAsync(CancellationToken ct = default);
        
        Task<ICommandNotification> StartInformationConsumerAsync(CancellationToken ct = default);
    }
}