using Shared.DataCollection.Domain.Models;

namespace ErrorLogs.Domain.Models.MessageIdStringBuilder
{
    public class MessageIdStringBuilder : IMessageIdStringBuilder,
        IIdStringBuilder<Guid>
    {
        public string GetString(Guid id) => $"Message:{id.ToString()}";
    }
}