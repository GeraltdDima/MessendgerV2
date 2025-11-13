using ErrorLogs.Shared.Domain.Models.MessageRequest;
using ErrorLogs.Shared.Domain.Dto;

namespace ErrorLogs.Infrastructure.Factories.MessageDtoFactory
{
    public interface IMessageDtoFactory
    {
        MessageDto Create(IMessageRequest request);
    }
}