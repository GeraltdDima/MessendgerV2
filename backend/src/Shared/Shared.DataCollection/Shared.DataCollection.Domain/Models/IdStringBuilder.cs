namespace Shared.DataCollection.Domain.Models
{
    public class IdStringBuilder<TId> : IIdStringBuilder<TId>
    {
        public string GetString(TId id)
        {
            if (id == null)
                return string.Empty;
            
            return id.ToString() ?? string.Empty;
        }
    }
}