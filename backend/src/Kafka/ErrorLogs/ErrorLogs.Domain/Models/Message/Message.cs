using ErrorLogs.Shared.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Shared.Domain.Models;

namespace ErrorLogs.Domain.Models.Message
{
    public class Message : IMessage, IBaseEntity<Message, Guid>
    {
        public Message(Guid id, string info, string stackTrace, PathString path, MessageTypes messageType, DateTime createdAt)
        {
            Id = id;
            Info = info;
            StackTrace = stackTrace;
            Path = path;
            MessageType = messageType;
            CreatedAt = createdAt;
        }

        public Guid Id { get; set; }
        
        public string Info { get; set; }
        
        public string StackTrace { get; set; }
        
        public PathString Path { get; set; }
        
        public MessageTypes MessageType { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public void Update(IMessage entity)
        {
            UpdateMessage(entity);
        }

        public void Update(Message entity)
        {
            UpdateMessage(entity);
        }

        private void UpdateMessage(IMessage message)
        {
            Info = message.Info;
            StackTrace = message.StackTrace;
            Path = message.Path;
            MessageType = message.MessageType;
        }

        public string GetString() => $"Message:{Id.ToString()}";
    }
}