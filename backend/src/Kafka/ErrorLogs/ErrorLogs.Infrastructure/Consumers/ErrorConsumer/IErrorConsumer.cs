using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Consumers.ErrorConsumer
{
    public interface IErrorConsumer
    {
        Task<ICommandNotification> StartErrorConsumerAsync(CancellationToken ct = default);
    }
}