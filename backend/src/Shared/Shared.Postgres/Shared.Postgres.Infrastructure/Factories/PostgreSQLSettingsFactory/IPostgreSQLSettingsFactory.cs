using Shared.Infrastructure.Factories.ConfigurationFactory;
using Shared.Postgres.Domain.Dto;

namespace Shared.Postgres.Infrastructure.Factories.PostgreSQLSettingsFactory
{
    public interface IPostgreSqLSettingsFactory : IConfigurationFactory<PostgreSqLSettingsDto>;
}