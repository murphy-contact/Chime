using Chime.Shared.Abstractions.Messaging;
using Chime.Shared.Abstractions.Modules;
using Microsoft.Extensions.Logging;

namespace Chime.Shared.Infrastructure.Messaging.Broker;

internal sealed class InMemoryMessageBroker : IMessageBroker
{
    private readonly ILogger<InMemoryMessageBroker> _logger;
    private readonly IModuleClient _moduleClient;

    public InMemoryMessageBroker(
        IModuleClient moduleClient,
        ILogger<InMemoryMessageBroker> logger)
    {
        _moduleClient = moduleClient;
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

        var tasks = messages.Select(x => _moduleClient.PublishAsync(x, cancellationToken));
        await Task.WhenAll(tasks);
    }
}