using Shared.Domain.Events;
using Shared.Domain.Models;

namespace Shared.Infrastructure.Repositories.Repository
{
    public interface IRepository<TEntity, TId> where TEntity : IBaseEntity<TEntity, TId>
    {
        Task<ICommandNotification> AddAsync(TEntity entity);
        
        Task<ICommandNotification> RemoveAsync(TEntity entity);
        
        Task<ICommandNotification> UpdateAsync(TId id, TEntity entity);
        
        Task<IQueryNotification<TEntity>> GetByIdAsync(TId id);
        
        Task<IQueryNotification<IQueryable<TEntity>>> GetAllAsync();
    }
}