using Shared.Domain.Commands;

namespace ErrorLogs.Domain.Commands
{
    public record ConsumeInformationCommand(CancellationToken Ct = default) : ICommand;
}