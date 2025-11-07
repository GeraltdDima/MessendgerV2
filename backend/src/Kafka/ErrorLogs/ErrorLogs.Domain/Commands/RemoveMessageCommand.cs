using Shared.Domain.Commands;

namespace ErrorLogs.Domain.Commands
{
    public record RemoveMessageCommand(Guid Id) : ICommand;
}