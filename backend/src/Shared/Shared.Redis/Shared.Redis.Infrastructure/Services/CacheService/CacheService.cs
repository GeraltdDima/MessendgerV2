using MediatR;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Redis.Domain.Commands;
using Shared.Redis.Domain.Queries;

namespace Shared.Redis.Infrastructure.Services.CacheService
{
    public class CacheService<TEntity, TId> : ICacheService<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IMediator _mediator;

        public CacheService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ICommandNotification> AddAsync(TEntity entity, TimeSpan expiration,
            CancellationToken ct = default) =>
            await _mediator.Send(new AddCacheValueCommand<TEntity, TId>(entity, expiration, ct));

        public async Task<ICommandNotification> RemoveAsync(TEntity entity, CancellationToken ct = default) =>
            await _mediator.Send(new RemoveCacheValueCommand<TEntity, TId>(entity, ct));

        public async Task<ICommandNotification> RemoveByKeyAsync(string key, CancellationToken ct = default) =>
            await _mediator.Send(new RemoveCacheValueByKeyCommand(key, ct));

        public async Task<IQueryNotification<TEntity?>> GetByIdAsync(string id) =>
            await _mediator.Send(new GetCacheValueByIdQuery<TEntity, TId>(id));
    }
}