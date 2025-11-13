using ErrorLogs.Shared.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace ErrorLogs.Shared.Domain.Models.MessageRequest
{
    public interface IMessageRequest
    {
        string Info { get; set; }
        
        string StackTrace { get; set; }
        
        PathString Path { get; set; }
        
        MessageTypes MessageType { get; set; }
    }
}