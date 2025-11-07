using ErrorLogs.Domain.Models.Message;
using ErrorLogs.Shared.Domain.Dto;

namespace ErrorLogs.Infrastructure.Factories.MessageDetailsFactory
{
    public interface IMessageDetailsFactory
    {
        MessageDetailsDto Create(Message dto);
    }
}