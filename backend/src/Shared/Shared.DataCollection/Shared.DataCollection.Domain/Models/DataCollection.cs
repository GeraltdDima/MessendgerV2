using Shared.Domain.Models;

namespace Shared.DataCollection.Domain.Models
{
    public class DataCollection<TEntity, TId> : IDataCollection<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private IQueryable<TEntity> _entities;
        
        public DataCollection(IQueryable<TEntity> entities)
        {
            _entities = entities;
        }

        public IQueryable<TEntity> Entities
        {
            get
            {
                return _entities;
            }
        }
        public TId Id { get; set; }

        public virtual string GetString() => "Entities";

        public void Update(IDataCollection<TEntity, TId> entity)
        {
            _entities = entity.Entities;
        }
    }
}