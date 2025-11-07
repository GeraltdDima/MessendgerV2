using ErrorLogs.Shared.Domain.Dto;
using Shared.Domain.Events;

namespace ErrorLogs.Infrastructure.Services.MessageService
{
    public interface IMessageService
    {
        Task<ICommandNotification> AddAsync(MessageDto dto);
        
        Task<ICommandNotification> RemoveAsync(Guid id);
        
        Task<ICommandNotification> UpdateAsync(Guid id, MessageDto dto);
        
        Task<IQueryNotification<MessageDetailsDto?>> GetByIdAsync(Guid id);
        
        Task<IQueryNotification<IQueryable<MessageDetailsDto>>> GetAllAsync();
    }
}