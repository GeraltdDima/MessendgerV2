using Auth.Domain.Dto;
using Microsoft.Extensions.Configuration;
using Shared.Infrastructure.Factories.ConfigurationFactory;

namespace Auth.Infrastructure.Factories.JwtSettingsFactory
{
    public class JwtSettingsFactory : ConfigurationFactory<JwtSettingsDto>,
        IJwtSettingsFactory
    {
        public JwtSettingsFactory(IConfiguration configuration) : base(configuration, "Jwt") { }
    }
}