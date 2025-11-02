using Microsoft.Extensions.DependencyInjection;
using Shared.Domain.Models;
using Shared.Redis.Infrastructure.Repositories.RedisRepository;
using Shared.Redis.Infrastructure.Services.CacheService;

namespace Shared.Redis.Core.Extensions.ServiceCollectionExtensions
{
    public static class RedisDepsExtensions
    {
        public static IServiceCollection UseRedisDeps<TEntity, TId>(this IServiceCollection services)
            where TEntity : IBaseEntity<TEntity, TId>
        {
            services
                .AddScoped<IRedisRepository<TEntity, TId>, RedisRepository<TEntity, TId>>()
                .AddScoped<ICacheService<TEntity, TId>, CacheService<TEntity, TId>>();
            
            return services;
        }
    }
}