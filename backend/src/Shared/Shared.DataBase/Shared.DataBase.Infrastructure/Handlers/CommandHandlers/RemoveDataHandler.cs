using Shared.DataBase.Domain.Commands;
using Shared.DataBase.Infrastructure.Repositories.DataBaseRepository;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace Shared.DataBase.Infrastructure.Handlers.CommandHandlers
{
    public class RemoveDataHandler<TEntity, TId> : ICommandHandler<RemoveDataCommand<TEntity, TId>>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        public RemoveDataHandler(IDataBaseRepository<TEntity, TId> repo)
        {
            _repo = repo;
        }
        
        private readonly IDataBaseRepository<TEntity, TId> _repo;

        public async Task<ICommandNotification> Handle(RemoveDataCommand<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _repo.RemoveAsync(request.Entity);

            return result;
        }
    }
}