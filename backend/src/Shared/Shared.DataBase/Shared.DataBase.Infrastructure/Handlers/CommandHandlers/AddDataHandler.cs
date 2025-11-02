using Shared.DataBase.Domain.Commands;
using Shared.DataBase.Infrastructure.Repositories.DataBaseRepository;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.CommandHandlers;

namespace Shared.DataBase.Infrastructure.Handlers.CommandHandlers
{
    public class AddDataHandler<TEntity, TId> : ICommandHandler<AddDataCommand<TEntity, TId>>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        public AddDataHandler(IDataBaseRepository<TEntity, TId> repo)
        {
            _repo = repo;
        }
        
        private readonly IDataBaseRepository<TEntity, TId> _repo;

        public async Task<ICommandNotification> Handle(AddDataCommand<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _repo.AddAsync(request.Entity);

            return result;
        }
    }
}