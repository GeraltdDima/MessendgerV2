using Shared.Domain.Models;
using Shared.Domain.Queries;

namespace Shared.Redis.Domain.Queries
{
    public record GetCacheValueByIdQuery<TEntity, TId>(
        string Id
    ) : IQuery<TEntity?> where TEntity : IBaseEntity<TEntity, TId>;
}