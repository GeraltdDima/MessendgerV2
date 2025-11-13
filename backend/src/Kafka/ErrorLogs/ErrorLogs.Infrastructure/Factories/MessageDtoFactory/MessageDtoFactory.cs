using ErrorLogs.Shared.Domain.Models.MessageRequest;
using ErrorLogs.Shared.Domain.Dto;

namespace ErrorLogs.Infrastructure.Factories.MessageDtoFactory
{
    public class MessageDtoFactory : IMessageDtoFactory
    {
        public MessageDto Create(IMessageRequest request)
        {
            var result = new MessageDto
            (
                request.Info,
                request.StackTrace,
                request.Path,
                request.MessageType
            );
            
            return result;
        }
    }
}