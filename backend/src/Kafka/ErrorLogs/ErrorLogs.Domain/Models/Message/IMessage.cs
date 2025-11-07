using ErrorLogs.Shared.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Shared.Domain.Models;

namespace ErrorLogs.Domain.Models.Message
{
    public interface IMessage : IBaseEntity<IMessage, Guid>
    {
        string Info { get; set; }
        
        string StackTrace { get; set; }
        
        PathString Path { get; set; }
        
        MessageTypes MessageType { get; set; }

        DateTime CreatedAt { get; set; }
    }
}