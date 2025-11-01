namespace Shared.Domain.Models
{
    public interface IBaseEntity<TEntity, TId>
    {
        TId Id { get; set; }
        
        void Update(TEntity entity);

        string GetString();
    }
}