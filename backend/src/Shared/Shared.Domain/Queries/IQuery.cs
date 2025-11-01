using MediatR;
using Shared.Domain.Events;

namespace Shared.Domain.Queries
{
    public interface IQuery<TValue> : IRequest<IQueryNotification<TValue>>;
}