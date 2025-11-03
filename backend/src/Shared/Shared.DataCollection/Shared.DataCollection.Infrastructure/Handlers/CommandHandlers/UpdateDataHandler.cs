using Shared.DataBase.Domain.Commands;
using Shared.DataCollection.Infrastructure.Repositories.DataCollectionRepository;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace Shared.DataCollection.Infrastructure.Handlers.CommandHandlers
{
    public class UpdateDataHandler<TEntity, TId> : ICommandHandler<UpdateDataCommand<TEntity, TId>>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IDataCollectionRepository<TEntity, TId> _repo;

        public UpdateDataHandler(IDataCollectionRepository<TEntity, TId> repo)
        {
            _repo = repo;
        }

        public async Task<ICommandNotification> Handle(UpdateDataCommand<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _repo.UpdateAsync(request.Id, request.Entity);

            return result;
        }
    }
}