using Shared.Domain.Models;
using Shared.Infrastructure.Repositories.Repository;

namespace Shared.DataBase.Infrastructure.Repositories.DataBaseRepository
{
    public interface IDataBaseRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>;
}