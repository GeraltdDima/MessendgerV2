using ErrorLogs.Domain.Models.Message;
using ErrorLogs.Domain.Models.MessageCollection;
using ErrorLogs.Domain.Models.MessageIdStringBuilder;
using Shared.DataBase.Infrastructure.Services.DataBaseService;
using Shared.DataCollection.Infrastructure.Repositories.DataCollectionRepository;
using Shared.Redis.Infrastructure.Services.CacheService;

namespace ErrorLogs.Infrastructure.Repositories.MessageRepository
{
    public class MessageRepository : DataCollectionRepository<Message, Guid, MessageCollection>,
        IMessageRepository
    {
        public MessageRepository
        (
            IDataBaseService<Message, Guid> dataBaseService,
            ICacheService<Message, Guid> cache,
            ICacheService<MessageCollection, Guid> collectionCache
        ) : base(dataBaseService, cache, collectionCache, new MessageIdStringBuilder()) { }
    }
}