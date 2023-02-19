namespace Chime.Shared.Infrastructure.Outbox;

public interface IInbox
{
    public bool Enabled { get; }
    Task HandleAsync(Guid messageId, string name, Func<Task> handler);
    Task CleanupAsync(DateTime? to = null);
}