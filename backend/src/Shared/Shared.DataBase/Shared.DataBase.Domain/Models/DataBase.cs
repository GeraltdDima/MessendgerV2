using Microsoft.EntityFrameworkCore;
using Shared.Domain.Models;

namespace Shared.DataBase.Domain.Models
{
    public abstract class DataBase<TEntity, TId> : DbContext
        where TEntity : class, IBaseEntity<TEntity, TId>
    {
        public DataBase(DbContextOptions<DataBase<TEntity, TId>> options) : base(options) { }
        
        public DbSet<TEntity> Items { get; set; }
    }
}