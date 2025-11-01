namespace Shared.Infrastructure.Factories.ConfigurationFactory
{
    public interface IConfigurationFactory<T> where T : class
    {
        T? GetConfig();
    }
}