using Microsoft.Extensions.Configuration;

namespace Shared.Infrastructure.Factories.ConfigurationFactory
{
    public abstract class ConfigurationFactory<T> : IConfigurationFactory<T> where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly string _section;
        
        public ConfigurationFactory(IConfiguration configuration, string section)
        {
            _configuration = configuration;
            _section = section;
        }

        public T? GetConfig()
        {
            var config = _configuration.GetSection(_section).Get<T>();

            return config;
        }
    }
}