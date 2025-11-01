using Shared.Domain.Commands;

namespace Shared.Redis.Domain.Commands
{
    public record RemoveCacheValueByKeyCommand
    (
        string Key,
        CancellationToken Ct = default
    ) : ICommand;
}