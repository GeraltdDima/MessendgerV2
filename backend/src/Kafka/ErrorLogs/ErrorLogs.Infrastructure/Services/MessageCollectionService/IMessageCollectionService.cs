using ErrorLogs.Domain.Models.Message;
using Shared.DataCollection.Infrastructure.Services.DataCollectionService;

namespace ErrorLogs.Infrastructure.Services.MessageCollectionService
{
    public interface IMessageCollectionService : IDataCollectionService<Message, Guid>;
}