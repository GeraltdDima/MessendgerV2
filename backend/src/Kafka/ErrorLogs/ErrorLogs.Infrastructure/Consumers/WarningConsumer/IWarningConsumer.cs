using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Consumers.WarningConsumer
{
    public interface IWarningConsumer
    {
        Task<ICommandNotification> StartWarningConsumerAsync(CancellationToken ct = default);
    }
}