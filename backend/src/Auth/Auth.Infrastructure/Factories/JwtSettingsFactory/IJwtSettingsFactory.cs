using Auth.Domain.Dto;
using Shared.Infrastructure.Factories.ConfigurationFactory;

namespace Auth.Infrastructure.Factories.JwtSettingsFactory
{
    public interface IJwtSettingsFactory : IConfigurationFactory<JwtSettingsDto>;
}