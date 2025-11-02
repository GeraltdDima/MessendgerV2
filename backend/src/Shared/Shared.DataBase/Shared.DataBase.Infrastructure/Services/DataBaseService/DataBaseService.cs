using MediatR;
using Shared.DataBase.Domain.Commands;
using Shared.DataBase.Domain.Queries;
using Shared.Domain.Events;
using Shared.Domain.Models;

namespace Shared.DataBase.Infrastructure.Services.DataBaseService
{
    public class DataBaseService<TEntity, TId> : IDataBaseService<TEntity, TId>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IMediator _mediator;
        
        public DataBaseService(IMediator mediator) => _mediator = mediator;

        public async Task<ICommandNotification> AddAsync(TEntity entity) =>
            await _mediator.Send(new AddDataCommand<TEntity, TId>(entity));

        public async Task<ICommandNotification> RemoveAsync(TEntity entity) =>
            await _mediator.Send(new RemoveDataCommand<TEntity, TId>(entity));

        public async Task<ICommandNotification> UpdateAsync(TId id, TEntity entity) =>
            await _mediator.Send(new UpdateDataCommand<TEntity, TId>(id, entity));

        public async Task<IQueryNotification<TEntity?>> GetByIdAsync(TId id) =>
            await _mediator.Send(new GetDataByIdQuery<TEntity, TId>(id));

        public async Task<IQueryNotification<IQueryable<TEntity>>> GetAllAsync() =>
            await _mediator.Send(new GetAllDataQuery<TEntity, TId>());
    }
}