using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Consumers.InformationConsumer
{
    public interface IInformationConsumer
    {
        Task<ICommandNotification> StartInformationConsumerAsync(CancellationToken ct = default);
    }
}