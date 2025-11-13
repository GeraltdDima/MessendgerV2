using Shared.Domain.Commands;

namespace Kafka.Shared.Domain.Commands
{
    public record ProduceDataCommand<TData>(string Topic, TData Data) : ICommand;
}