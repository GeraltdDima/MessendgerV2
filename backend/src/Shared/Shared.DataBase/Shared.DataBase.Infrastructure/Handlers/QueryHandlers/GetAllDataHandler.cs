using Shared.DataBase.Domain.Queries;
using Shared.DataBase.Infrastructure.Repositories.DataBaseRepository;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.QueryHandlers;

namespace Shared.DataBase.Infrastructure.Handlers.QueryHandlers
{
    public class GetAllDataHandler<TEntity, TId> : IQueryHandler<GetAllDataQuery<TEntity, TId>, IQueryable<TEntity>>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IDataBaseRepository<TEntity, TId> _repo;

        public GetAllDataHandler(IDataBaseRepository<TEntity, TId> repo)
        {
            _repo = repo;
        }

        public async Task<IQueryNotification<IQueryable<TEntity>>> Handle(GetAllDataQuery<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetAllAsync();

            return result;
        }
    }
}