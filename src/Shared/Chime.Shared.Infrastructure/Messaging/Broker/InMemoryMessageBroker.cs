using Chime.Shared.Abstractions.Messaging;
using Chime.Shared.Abstractions.Modules;
using Chime.Shared.Infrastructure.Messaging.Dispatcher;
using Microsoft.Extensions.Logging;

namespace Chime.Shared.Infrastructure.Messaging.Broker;

internal sealed class InMemoryMessageBroker : IMessageBroker
{
    private readonly IAsyncMessageDispatcher _asyncMessageDispatcher;
    private readonly ILogger<InMemoryMessageBroker> _logger;
    private readonly MessagingOptions _messagingOptions;
    private readonly IModuleClient _moduleClient;

    public InMemoryMessageBroker(
        IModuleClient moduleClient,
        IAsyncMessageDispatcher asyncMessageDispatcher,
        MessagingOptions messagingOptions,
        ILogger<InMemoryMessageBroker> logger)
    {
        _moduleClient = moduleClient;
        _asyncMessageDispatcher = asyncMessageDispatcher;
        _messagingOptions = messagingOptions;
        _logger = logger;
    }

    public Task PublishAsync(IMessage message, CancellationToken cancellationToken = default)
    {
        return PublishAsync(cancellationToken, message);
    }

    public Task PublishAsync(IMessage[] messages, CancellationToken cancellationToken = default)
    {
        return PublishAsync(cancellationToken, messages);
    }

    private async Task PublishAsync(CancellationToken cancellationToken, params IMessage[] messages)
    {
        if (messages is null) return;

        messages = messages.Where(x => x is not null).ToArray();

        if (!messages.Any()) return;

        var tasks =
            _messagingOptions.UseAsyncDispatcher
                ? messages.Select(x => _asyncMessageDispatcher.PublishAsync(x, cancellationToken))
                : messages.Select(x => _moduleClient.PublishAsync(x, cancellationToken));
        await Task.WhenAll(tasks);
    }
}