using Shared.Domain.Commands;

namespace Kafka.Domain.Commands
{
    public record StartKafkaConsumerCommand<TData>(string Topic, Func<TData, Task> Predicate, CancellationToken Ct = default) :
        ICommand;
}