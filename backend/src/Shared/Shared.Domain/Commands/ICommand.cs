using MediatR;
using Shared.Domain.Events;

namespace Shared.Domain.Commands
{
    public interface ICommand : IRequest<ICommandNotification>;
}