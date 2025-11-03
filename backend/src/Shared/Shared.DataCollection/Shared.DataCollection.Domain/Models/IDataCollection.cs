using Shared.Domain.Models;

namespace Shared.DataCollection.Domain.Models
{
    public interface IDataCollection<TEntity, TId> : IBaseEntity<IDataCollection<TEntity, TId>, TId>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        IQueryable<TEntity> Entities { get; }
    }
}