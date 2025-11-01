using MediatR;
using Shared.Domain.Events;

namespace Shared.Infrastructure.Handlers.NotificationHandlers
{
    public interface IQueryNotificationHandler<TNotification, TQuery> : INotificationHandler<TNotification>
        where TNotification : IQueryNotification<TQuery>;
}