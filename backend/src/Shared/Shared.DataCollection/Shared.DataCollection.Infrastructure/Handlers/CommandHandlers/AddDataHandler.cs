using Shared.DataBase.Domain.Commands;
using Shared.DataCollection.Infrastructure.Repositories.DataCollectionRepository;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace Shared.DataCollection.Infrastructure.Handlers.CommandHandlers
{
    public class AddDataHandler<TEntity, TId> : ICommandHandler<AddDataCommand<TEntity, TId>>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IDataCollectionRepository<TEntity, TId> _repo;

        public AddDataHandler(IDataCollectionRepository<TEntity, TId> repo)
        {
            _repo = repo;
        }

        public async Task<ICommandNotification> Handle(AddDataCommand<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _repo.AddAsync(request.Entity);

            return result;
        }
    }
}