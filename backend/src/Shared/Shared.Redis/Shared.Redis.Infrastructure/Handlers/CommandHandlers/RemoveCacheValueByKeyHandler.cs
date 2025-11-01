using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.CommandHandlers;
using Shared.Redis.Domain.Commands;
using Shared.Redis.Infrastructure.Repositories.RedisRepository;

namespace Shared.Redis.Infrastructure.Handlers.CommandHandlers
{
    public class RemoveCacheValueByKeyHandler<TEntity, TId> : ICommandHandler<RemoveCacheValueByKeyCommand>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IRedisRepository<TEntity, TId> _redisRepository;

        public RemoveCacheValueByKeyHandler(IRedisRepository<TEntity, TId> redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public async Task<ICommandNotification> Handle(RemoveCacheValueByKeyCommand request, CancellationToken cancellationToken)
        {
            var result = await _redisRepository.RemoveByKeyAsync(request.Key, request.Ct);

            return result;
        }
    }
}