using ErrorLogs.Domain.Queries;
using ErrorLogs.Infrastructure.Factories.MessageDetailsFactory;
using ErrorLogs.Infrastructure.Services.MessageCollectionService;
using ErrorLogs.Shared.Domain.Dto;
using Shared.DataBase.Domain.Events.QueryNotifications;
using Shared.Domain.Events;
using Shared.Infrastructure.Handlers.QueryHandlers;

namespace ErrorLogs.Infrastructure.Handlers.QueryHandlers
{
    public class GetAllMessagesHandler : IQueryHandler<GetAllMessagesQuery, IQueryable<MessageDetailsDto>>
    {
        private readonly IMessageCollectionService _messageCollectionService;
        private readonly IMessageDetailsFactory _messageDetailsFactory;

        public GetAllMessagesHandler(IMessageCollectionService messageCollectionService,
            IMessageDetailsFactory messageDetailsFactory)
        {
            _messageCollectionService = messageCollectionService;
            _messageDetailsFactory = messageDetailsFactory;
        }

        public async Task<IQueryNotification<IQueryable<MessageDetailsDto>>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _messageCollectionService.GetAllAsync();

            var messages = result.Value.Select(message => _messageDetailsFactory.Create(message));

            return new AllDataFound<MessageDetailsDto>(messages, DateTime.UtcNow);
        }
    }
}