using Microsoft.Extensions.Configuration;
using Shared.Infrastructure.Factories.ConfigurationFactory;
using Shared.Redis.Domain.Dto;

namespace Shared.Redis.Infrastructure.Factories.RedisSettingsFactory
{
    public class RedisSettingsFactory : ConfigurationFactory<RedisSettingsDto>,
        IRedisSettingsFactory
    {
        public RedisSettingsFactory(IConfiguration configuration) : base(configuration, "Redis") { }
    }
}