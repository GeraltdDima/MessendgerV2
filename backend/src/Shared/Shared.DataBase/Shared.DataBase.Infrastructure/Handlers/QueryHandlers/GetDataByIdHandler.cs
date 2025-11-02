using Shared.DataBase.Domain.Queries;
using Shared.DataBase.Infrastructure.Repositories.DataBaseRepository;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.QueryHandlers;

namespace Shared.DataBase.Infrastructure.Handlers.QueryHandlers
{
    public class GetDataByIdHandler<TEntity, TId> : IQueryHandler<GetDataByIdQuery<TEntity, TId>, TEntity?>
        where TEntity : IBaseEntity<TEntity, TId>
    {
        private readonly IDataBaseRepository<TEntity, TId> _repo;

        public GetDataByIdHandler(IDataBaseRepository<TEntity, TId> repo)
        {
            _repo = repo;
        }

        public async Task<IQueryNotification<TEntity?>> Handle(GetDataByIdQuery<TEntity, TId> request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetByIdAsync(request.Id);

            return result;
        }
    }
}