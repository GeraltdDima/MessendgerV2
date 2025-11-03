using Shared.DataBase.Domain.Queries;
using Shared.DataCollection.Infrastructure.Repositories.DataCollectionRepository;
using Shared.Domain.Events;
using Shared.Domain.Models;
using Shared.Infrastructure.Handlers.QueryHandlers;

namespace Shared.DataCollection.Infrastructure.Handlers.QueryHandlers
{
    public class GetDataByIdHandler<TEntity, TId> : IQueryHandler<GetDataByIdQuery<TEntity, TId>, TEntity?>
        where TEntity : IBaseEntity<TEntity, TId>   
    {
        private readonly IDataCollectionRepository<TEntity, TId> _repo;

        public GetDataByIdHandler(IDataCollectionRepository<TEntity, TId> repo)
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