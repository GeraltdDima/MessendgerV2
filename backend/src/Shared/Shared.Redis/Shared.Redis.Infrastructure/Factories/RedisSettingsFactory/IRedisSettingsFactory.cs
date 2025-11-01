using Shared.Infrastructure.Factories.ConfigurationFactory;
using Shared.Redis.Domain.Dto;

namespace Shared.Redis.Infrastructure.Factories.RedisSettingsFactory
{
    public interface IRedisSettingsFactory : IConfigurationFactory<RedisSettingsDto>;
}