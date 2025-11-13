using ErrorLogs.Shared.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace ErrorLogs.Shared.Domain.Models.MessageRequest
{
    public class WarningRequest : IMessageRequest
    {
        public WarningRequest(string info, string stackTrace, PathString path)
        {
            Info = info;
            StackTrace = stackTrace;
            Path = path;
        }
        
        public string Info { get; set; }
        
        public string StackTrace { get; set; }

        public PathString Path { get; set; }

        public MessageTypes MessageType { get; set; } = MessageTypes.Warning;
    }
}