namespace Shared.DataCollection.Domain.Models
{
    public interface IIdStringBuilder<TId>
    {
        string GetString(TId id);
    }
}