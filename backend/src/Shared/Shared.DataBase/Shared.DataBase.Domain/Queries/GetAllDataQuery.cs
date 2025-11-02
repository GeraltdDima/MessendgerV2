using Shared.Domain.Models;
using Shared.Domain.Queries;

namespace Shared.DataBase.Domain.Queries
{
    public record GetAllDataQuery<TEntity, TId>() :
        IQuery<IQueryable<TEntity>>
        where TEntity : IBaseEntity<TEntity, TId>;
}