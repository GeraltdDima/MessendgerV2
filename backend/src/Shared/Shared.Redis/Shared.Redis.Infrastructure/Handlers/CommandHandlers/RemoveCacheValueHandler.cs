using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.CommandHandlers;
using Shared.Redis.Domain.Commands;
using Shared.Redis.Infrastructure.Repositories.RedisRepository;

namespace Shared.Redis.Infrastructure.Handlers.CommandHandlers
{
    public class RemoveCacheValueHandler<TEntity, TId> : ICommandHandler<RemoveCacheValueCommand<TEntity, TId>>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IRedisRepository<TEntity, TId> _redisRepository;

        public RemoveCacheValueHandler(IRedisRepository<TEntity, TId> redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public async Task<ICommandNotification> Handle(RemoveCacheValueCommand<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _redisRepository.RemoveAsync(request.Entity, request.Ct);

            return result;
        }
    }
}