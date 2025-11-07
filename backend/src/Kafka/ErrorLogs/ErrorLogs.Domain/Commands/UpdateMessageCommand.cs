using ErrorLogs.Shared.Domain.Dto;
using Shared.Domain.Commands;

namespace ErrorLogs.Domain.Commands
{
    public record UpdateMessageCommand(Guid Id, MessageDto Dto) : ICommand;
}