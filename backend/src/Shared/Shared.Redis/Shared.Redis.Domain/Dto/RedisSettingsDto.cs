namespace Shared.Redis.Domain.Dto
{
    public record RedisSettingsDto
    (
        string ConnectionString,
        string InstanceName
    );
}