using Chime.Shared.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Chime.Shared.Infrastructure.Outbox;

internal sealed class OutboxBroker : IOutboxBroker
{
    private readonly OutboxTypeRegistry _registry;
    private readonly IServiceProvider _serviceProvider;

    public OutboxBroker(IServiceProvider serviceProvider, OutboxTypeRegistry registry, OutboxOptions options)
    {
        _serviceProvider = serviceProvider;
        _registry = registry;
        Enabled = options.Enabled;
    }

    public bool Enabled { get; }

    public async Task SendAsync(params IMessage[] messages)
    {
        var message = messages[0]; // Not possible to send messages from different modules at once
        var outboxType = _registry.Resolve(message);
        if (outboxType is null)
            throw new InvalidOperationException($"Outbox is not registered for module: '{message.GetModuleName()}'.");

        using var scope = _serviceProvider.CreateScope();
        var outbox = (IOutbox)scope.ServiceProvider.GetRequiredService(outboxType);
        await outbox.SaveAsync(messages);
    }
}