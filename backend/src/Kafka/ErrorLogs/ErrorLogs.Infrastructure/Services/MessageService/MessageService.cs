using ErrorLogs.Domain.Commands;
using ErrorLogs.Domain.Queries;
using ErrorLogs.Shared.Domain.Dto;
using MediatR;
using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly IMediator _mediator;

        public MessageService(IMediator mediator) => _mediator = mediator;

        public async Task<ICommandNotification> AddAsync(MessageDto dto) =>
            await _mediator.Send(new CreateMessageCommand(dto));

        public async Task<ICommandNotification> RemoveAsync(Guid id) =>
            await _mediator.Send(new RemoveMessageCommand(id));

        public async Task<ICommandNotification> UpdateAsync(Guid id, MessageDto dto) =>
            await _mediator.Send(new UpdateMessageCommand(id, dto));

        public async Task<IQueryNotification<MessageDetailsDto?>> GetByIdAsync(Guid id) =>
            await _mediator.Send(new GetMessageByIdQuery(id));

        public async Task<IQueryNotification<IQueryable<MessageDetailsDto>>> GetAllAsync() =>
            await _mediator.Send(new GetAllMessagesQuery());
    }
}