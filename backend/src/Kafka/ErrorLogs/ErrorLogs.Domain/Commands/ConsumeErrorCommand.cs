using Shared.Domain.Commands;

namespace ErrorLogs.Domain.Commands
{
    public record ConsumeErrorCommand(CancellationToken Ct = default) : ICommand;
}