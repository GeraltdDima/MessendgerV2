using Shared.Domain.Commands;
using Shared.Domain.Models;

namespace Shared.Redis.Domain.Commands
{
    public record AddCacheValueCommand<TEntity, TId>(
        TEntity Entity,
        TimeSpan Expiration,
        CancellationToken Ct = default
    ) : ICommand where TEntity : IBaseEntity<TEntity, TId>;
}