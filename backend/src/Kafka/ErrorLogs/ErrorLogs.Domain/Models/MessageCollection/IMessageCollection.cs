using Shared.DataCollection.Domain.Models;

namespace ErrorLogs.Domain.Models.MessageCollection
{
    public interface IMessageCollection : IDataCollection<Message.Message, Guid>;
}