using ErrorLogs.Domain.Commands;
using MediatR;
using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Services.MessageConsumerService
{
    public class MessageConsumerService : IMessageConsumerService
    {
        private readonly IMediator _mediator;

        public MessageConsumerService(IMediator mediator) => _mediator = mediator;

        public async Task<ICommandNotification> StartErrorConsumerAsync(CancellationToken ct = default) =>
            await _mediator.Send(new ConsumeErrorCommand(ct));

        public async Task<ICommandNotification> StartWarningConsumerAsync(CancellationToken ct = default) =>
            await _mediator.Send(new ConsumeWarningCommand(ct));

        public async Task<ICommandNotification> StartInformationConsumerAsync(CancellationToken ct = default) =>
            await _mediator.Send(new ConsumeInformationCommand(ct));
    }
}