using Shared.DataCollection.Domain.Models;
using Shared.Domain.Models;

namespace ErrorLogs.Domain.Models.MessageCollection
{
    public class MessageCollection : DataCollection<Message.Message, Guid>,
        IMessageCollection, IBaseEntity<MessageCollection, Guid>
    {
        public MessageCollection(IQueryable<Message.Message> entities) : base(entities) { }

        public Guid Id { get; set; }

        public void Update(MessageCollection entity)
        {
            base.Update(entity);
        }

        public override string GetString() => "Messages";
    }
}