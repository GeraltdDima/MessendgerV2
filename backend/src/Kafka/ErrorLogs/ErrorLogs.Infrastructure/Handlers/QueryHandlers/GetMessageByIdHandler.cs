using ErrorLogs.Domain.Queries;
using ErrorLogs.Infrastructure.Factories.MessageDetailsFactory;
using ErrorLogs.Infrastructure.Services.MessageCollectionService;
using ErrorLogs.Shared.Domain.Dto;
using Shared.DataBase.Domain.Events.QueryNotifications;
using Shared.Domain.Events;
using Shared.Infrastructure.Handlers.QueryHandlers;

namespace ErrorLogs.Infrastructure.Handlers.QueryHandlers
{
    public class GetMessagebyIdHandler : IQueryHandler<GetMessageByIdQuery, MessageDetailsDto?>
    {
        private readonly IMessageCollectionService _messageCollectionService;
        private readonly IMessageDetailsFactory _messageDetailsFactory;

        public GetMessagebyIdHandler(IMessageCollectionService messageCollectionService,
            IMessageDetailsFactory messageDetailsFactory)
        {
            _messageCollectionService = messageCollectionService;
            _messageDetailsFactory = messageDetailsFactory;
        }

        public async Task<IQueryNotification<MessageDetailsDto?>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _messageCollectionService.GetByIdAsync(request.Id);

            if (result.Value == null)
                return new DataNotFound<MessageDetailsDto>(null, DateTime.UtcNow);
            
            var messageDetails = _messageDetailsFactory.Create(result.Value);
            
            return new DataFound<MessageDetailsDto?>(messageDetails, DateTime.UtcNow);
        }
    }
}