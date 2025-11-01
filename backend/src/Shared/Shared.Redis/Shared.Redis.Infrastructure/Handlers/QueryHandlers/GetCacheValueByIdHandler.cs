using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.QueryHandlers;
using Shared.Redis.Domain.Queries;
using Shared.Redis.Infrastructure.Repositories.RedisRepository;

namespace Shared.Redis.Infrastructure.Handlers.QueryHandlers
{
    public class GetCacheValueByIdHandler<TEntity, TId> : IQueryHandler<GetCacheValueByIdQuery<TEntity, TId>, TEntity?>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IRedisRepository<TEntity, TId> _redisRepository;

        public GetCacheValueByIdHandler(IRedisRepository<TEntity, TId> redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public async Task<IQueryNotification<TEntity?>> Handle(GetCacheValueByIdQuery<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _redisRepository.GetByIdAsync(request.Id);

            return result;
        }
    }
}