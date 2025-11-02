using Shared.Domain.Commands;
using Shared.Domain.Models;

namespace Shared.DataBase.Domain.Commands
{
    public record UpdateDataCommand<TEntity, TId>(
        TId Id,
        TEntity Entity
    ) : ICommand where TEntity : IBaseEntity<TEntity, TId>;
}