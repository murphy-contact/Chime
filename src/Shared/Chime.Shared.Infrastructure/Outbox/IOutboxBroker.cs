using Chime.Shared.Abstractions.Messaging;

namespace Chime.Shared.Infrastructure.Outbox;

public interface IOutboxBroker
{
    bool Enabled { get; }
    Task SendAsync(params IMessage[] messages);
}