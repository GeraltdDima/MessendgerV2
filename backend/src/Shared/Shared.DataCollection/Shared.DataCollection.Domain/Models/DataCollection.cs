using Shared.Domain.Models;

namespace Shared.DataCollection.Domain.Models
{
    public class DataCollection<TEntity, TId> : IDataCollection<TEntity, TId>,
        IBaseEntity<DataCollection<TEntity, TId>, TId> 
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private IQueryable<TEntity> _entities;

        public DataCollection(IQueryable<TEntity> entities)
        {
            _entities = entities;
        }

        public IQueryable<TEntity> Entities => _entities;
            
        public TId Id { get; set; }

        public virtual string GetString() => "Entities";

        public void Update(IDataCollection<TEntity, TId> entity)
        {
            _entities = entity.Entities;
        }

        public void Update(DataCollection<TEntity, TId> entity)
        {
            _entities = entity.Entities;
        }
    }
}