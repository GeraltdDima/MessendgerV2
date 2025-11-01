using MediatR;

namespace Shared.Domain.Events
{
    public interface IQueryNotification<TValue> : INotification
    {
        TValue Value { get; set; }
    }
}