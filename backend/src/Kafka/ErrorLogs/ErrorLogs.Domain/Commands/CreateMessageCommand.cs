using ErrorLogs.Shared.Domain.Dto;
using Shared.Domain.Commands;

namespace ErrorLogs.Domain.Commands
{
    public record CreateMessageCommand(MessageDto Dto) : ICommand;
}