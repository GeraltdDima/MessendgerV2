using Microsoft.Extensions.Configuration;
using Shared.Infrastructure.Factories.ConfigurationFactory;
using Shared.Postgres.Domain.Dto;

namespace Shared.Postgres.Infrastructure.Factories.PostgreSQLSettingsFactory
{
    public class PostgreSqlSettingsFactory : ConfigurationFactory<PostgreSqLSettingsDto>,
        IPostgreSqLSettingsFactory
    {
        public PostgreSqlSettingsFactory(IConfiguration configuration) : base(configuration, "PostgreSQL") { }
    }
}