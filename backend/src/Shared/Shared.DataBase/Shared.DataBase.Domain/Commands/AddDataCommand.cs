using Shared.Domain.Commands;
using Shared.Domain.Models;

namespace Shared.DataBase.Domain.Commands
{
    public record AddDataCommand<TEntity, TId>(
        TEntity Entity
    ) : ICommand where TEntity : IBaseEntity<TEntity, TId>;
}