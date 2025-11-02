using Microsoft.Extensions.DependencyInjection;
using Shared.Redis.Infrastructure.Factories.RedisSettingsFactory;

namespace Shared.Redis.Core.Extensions.ServiceCollectionExtensions
{
    public static class RedisExtensions
    {
        public static IServiceCollection UseRedis
        (
            this IServiceCollection services,
            IRedisSettingsFactory redisSettingsFactory
        )
        {
            var settings = redisSettingsFactory.GetConfig();

            if (settings == null)
                throw new Exception("Redis settings not found");

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = settings.ConnectionString;
                options.InstanceName = settings.InstanceName;
            });
            
            return services;
        }
    }
}