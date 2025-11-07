using ErrorLogs.Domain.Models.Message;
using MediatR;
using Shared.DataCollection.Infrastructure.Services.DataCollectionService;

namespace ErrorLogs.Infrastructure.Services.MessageCollectionService
{
    public class MessageService : DataCollectionService<Message, Guid>,
        IMessageCollectionService
    {
        public MessageService(IMediator mediator) : base(mediator) { }
    }
}