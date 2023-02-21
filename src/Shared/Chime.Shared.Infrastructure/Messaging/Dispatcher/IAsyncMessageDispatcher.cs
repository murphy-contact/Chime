using Chime.Shared.Abstractions.Messaging;

namespace Chime.Shared.Infrastructure.Messaging.Dispatcher;

public interface IAsyncMessageDispatcher
{
    Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class, IMessage;
}