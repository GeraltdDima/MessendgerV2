using MediatR;
using Shared.Domain.Events;
using Shared.Domain.Queries;

namespace Shared.Infrastructure.Handlers.QueryHandlers
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, IQueryNotification<TResult>>
        where TQuery : IQuery<TResult>;
}