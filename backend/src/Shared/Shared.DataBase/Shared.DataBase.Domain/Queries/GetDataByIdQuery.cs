using Shared.Domain.Models;
using Shared.Domain.Queries;

namespace Shared.DataBase.Domain.Queries
{
    public record GetDataByIdQuery<TEntity, TId>(
        TId Id
    ) : IQuery<TEntity?>
        where TEntity : IBaseEntity<TEntity, TId>;
}