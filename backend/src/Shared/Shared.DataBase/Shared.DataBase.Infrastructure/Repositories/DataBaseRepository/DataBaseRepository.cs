using Microsoft.EntityFrameworkCore;
using Shared.DataBase.Domain.Events.CommandNotifications;
using Shared.DataBase.Domain.Events.QueryNotifications;
using Shared.DataBase.Domain.Models;
using Shared.Domain.Events;
using Shared.Domain.Models;

namespace Shared.DataBase.Infrastructure.Repositories.DataBaseRepository
{
    public class DataBaseRepository<TContext, TEntity, TId> : IDataBaseRepository<TEntity, TId>
        where TEntity : class, IBaseEntity<TEntity, TId>
        where TContext : DataBase<TEntity, TId>
    {
        public DataBaseRepository(TContext context) => _context = context;
        
        private TContext _context;

        public async Task<ICommandNotification> AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return new DataAdded<TEntity>(entity, DateTime.Now);
        }

        public async Task<ICommandNotification> RemoveAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            
            return new DataRemoved<TEntity>(entity, DateTime.Now);
        }

        public async Task<ICommandNotification> UpdateAsync(TId id, TEntity entity)
        {
            var notification = await GetByIdAsync(id);
            var oldEntity = notification.Value;

            if (oldEntity == null)
                return new DataUpdatedFailed<TId>(id, DateTime.UtcNow);
            
            oldEntity.Update(entity);
            _context.Update(oldEntity);
            
            await _context.SaveChangesAsync();

            return new DataUpdated<TEntity>(oldEntity, DateTime.UtcNow);
        }

        public async Task<IQueryNotification<TEntity?>> GetByIdAsync(TId id)
        {
            var result = await _context.Items.FirstOrDefaultAsync(x => x.Id.Equals(id));
            
            if (result == null)
                return new DataNotFound<TEntity>(result, DateTime.UtcNow);
            
            return new DataFound<TEntity>(result, DateTime.UtcNow);
        }

        public async Task<IQueryNotification<IQueryable<TEntity>>> GetAllAsync()
        {
            var result = _context.Items.OrderBy(item => item.Id);
            
            var notification = new AllDataFound<TEntity>(result, DateTime.UtcNow);

            return await Task.FromResult(notification);
        }
    }
}