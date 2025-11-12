using Shared.Domain.Commands;

namespace ErrorLogs.Domain.Commands
{
    public record ConsumeWarningCommand(CancellationToken Ct = default) : ICommand;
}