using Shared.DataBase.Domain.Commands;
using Shared.DataBase.Infrastructure.Repositories.DataBaseRepository;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace Shared.DataBase.Infrastructure.Handlers.CommandHandlers
{
    public class UpdateDataHandler<TEntity, TId> : ICommandHandler<UpdateDataCommand<TEntity, TId>>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        public UpdateDataHandler(IDataBaseRepository<TEntity, TId> repo)
        {
            _repo = repo;
        }
        
        private readonly IDataBaseRepository<TEntity, TId> _repo;

        public async Task<ICommandNotification> Handle(UpdateDataCommand<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _repo.UpdateAsync(request.Id, request.Entity);

            return result;
        }
    }
}