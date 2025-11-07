using ErrorLogs.Shared.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace ErrorLogs.Shared.Domain.Dto
{
    public record MessageDetailsDto
    (
        Guid Id,
        string Info,
        string Stacktrace,
        PathString Path,
        MessageTypes MessageType,
        DateTime CreatedAt
    );
}