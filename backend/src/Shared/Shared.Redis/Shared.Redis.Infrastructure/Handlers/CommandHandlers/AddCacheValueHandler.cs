using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.CommandHandlers;
using Shared.Redis.Domain.Commands;
using Shared.Redis.Infrastructure.Repositories.RedisRepository;

namespace Shared.Redis.Infrastructure.Handlers.CommandHandlers
{
    public class AddCacheValueHandler<TEntity, TId> : ICommandHandler<AddCacheValueCommand<TEntity, TId>>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IRedisRepository<TEntity, TId> _redisRepository;

        public AddCacheValueHandler(IRedisRepository<TEntity, TId> redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public async Task<ICommandNotification> Handle(AddCacheValueCommand<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _redisRepository.AddAsync(request.Entity, request.Expiration, request.Ct);

            return result;
        }
    }
}