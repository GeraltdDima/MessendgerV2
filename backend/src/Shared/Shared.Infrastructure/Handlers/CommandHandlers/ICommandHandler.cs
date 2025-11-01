using MediatR;
using Shared.Domain.Commands;
using Shared.Domain.Events;

namespace Shared.Infrastructure.Handlers.CommandHandlers
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, ICommandNotification>
        where TCommand : ICommand, IRequest<ICommandNotification>;
}