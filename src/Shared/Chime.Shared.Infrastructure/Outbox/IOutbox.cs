using Chime.Shared.Abstractions.Messaging;

namespace Chime.Shared.Infrastructure.Outbox;

public interface IOutbox
{
    bool Enabled { get; }

    Task SaveAsync(params IMessage[] messages);
    Task PublishUnsentAsync();
    Task CleanupAsync(DateTime? to = null);
}