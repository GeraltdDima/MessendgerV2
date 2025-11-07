using ErrorLogs.Domain.Models.Message;
using Shared.DataCollection.Infrastructure.Repositories.DataCollectionRepository;

namespace ErrorLogs.Infrastructure.Repositories.MessageRepository
{
    public interface IMessageRepository : IDataCollectionRepository<Message, Guid>;
}