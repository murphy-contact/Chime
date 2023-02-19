using Chime.Shared.Abstractions.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Chime.Shared.Infrastructure.Outbox;

internal sealed class EfOutbox<T> : IOutbox where T : DbContext
{
    public bool Enabled { get; }

    public Task PublishUnsentAsync()
    {
        throw new NotImplementedException();
    }

    public Task CleanupAsync(DateTime? to = null)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(params IMessage[] messages)
    {
        throw new NotImplementedException();
    }
}