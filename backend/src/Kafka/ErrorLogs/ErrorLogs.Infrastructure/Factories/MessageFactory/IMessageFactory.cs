using ErrorLogs.Domain.Models.Message;
using ErrorLogs.Shared.Domain.Dto;

namespace ErrorLogs.Infrastructure.Factories.MessageFactory
{
    public interface IMessageFactory
    {
        Message Create(MessageDto dto);
    }
}