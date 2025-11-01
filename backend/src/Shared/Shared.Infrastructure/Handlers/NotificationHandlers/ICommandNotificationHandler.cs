using MediatR;
using Shared.Domain.Events;

namespace Shared.Infrastructure.Handlers.NotificationHandlers
{
    public interface ICommandNotificationHandler<TNotification> : INotificationHandler<TNotification>
        where TNotification : ICommandNotification;
}