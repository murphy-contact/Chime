namespace Chime.Shared.Infrastructure.Messaging.Outbox;

public class OutboxMessage
{
    public Guid Id { get; set; }
    public Guid CorrelationId { get; set; }
    public Guid? UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Data { get; set; } = null!;
    public string TraceId { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? SentAt { get; set; }
}