using ErrorLogs.Shared.Domain.Dto;
using Shared.Domain.Queries;

namespace ErrorLogs.Domain.Queries
{
    public record GetAllMessagesQuery() : IQuery<IQueryable<MessageDetailsDto>>;
}