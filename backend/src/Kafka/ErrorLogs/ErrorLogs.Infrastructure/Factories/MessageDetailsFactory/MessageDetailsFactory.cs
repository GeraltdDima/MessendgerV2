using ErrorLogs.Domain.Models.Message;
using ErrorLogs.Shared.Domain.Dto;

namespace ErrorLogs.Infrastructure.Factories.MessageDetailsFactory
{
    public class MessageDetailsFactory : IMessageDetailsFactory
    {
        public MessageDetailsDto Create(Message dto)
        {
            var messageDetails = new MessageDetailsDto
            (
                dto.Id,
                dto.Info,
                dto.StackTrace,
                dto.Path,
                dto.MessageType,
                dto.CreatedAt
            );
            
            return messageDetails;
        }
    }
}