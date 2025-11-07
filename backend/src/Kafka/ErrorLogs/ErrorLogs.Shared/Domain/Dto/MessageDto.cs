using ErrorLogs.Shared.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace ErrorLogs.Shared.Domain.Dto
{
    public record MessageDto
    (
        string Info,
        string Stacktrace,
        PathString Path,
        MessageTypes MessageType
    );
}