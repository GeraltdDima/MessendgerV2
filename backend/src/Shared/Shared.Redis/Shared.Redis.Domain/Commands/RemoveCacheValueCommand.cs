using Shared.Domain.Commands;
using Shared.Domain.Models;

namespace Shared.Redis.Domain.Commands
{
    public record RemoveCacheValueCommand<TEntity, TId>(
        TEntity Entity,
        CancellationToken Ct = default
    ) : ICommand where TEntity : IBaseEntity<TEntity, TId>;
}