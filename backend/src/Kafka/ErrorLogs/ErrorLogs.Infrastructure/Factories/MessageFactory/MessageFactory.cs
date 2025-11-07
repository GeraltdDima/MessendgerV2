using ErrorLogs.Domain.Models.Message;
using ErrorLogs.Shared.Domain.Dto;

namespace ErrorLogs.Infrastructure.Factories.MessageFactory
{
    public class MessageFactory : IMessageFactory
    {
        public Message Create(MessageDto dto)
        {
            var result = new Message
            (
                Guid.NewGuid(),
                dto.Info,
                dto.Stacktrace,
                dto.Path,
                dto.MessageType,
                DateTime.UtcNow
            );
            
            return result;
        }
    }
}