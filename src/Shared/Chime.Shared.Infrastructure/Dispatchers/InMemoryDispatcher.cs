using Chime.Shared.Abstractions.Commands;
using Chime.Shared.Abstractions.Dispatchers;
using Chime.Shared.Abstractions.Queries;

namespace Chime.Shared.Infrastructure.Dispatchers;

internal sealed class InMemoryDispatcher : IDispatcher
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public InMemoryDispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    public Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand
    {
        return _commandDispatcher.SendAsync(command, cancellationToken);
    }

    public Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        where TResult : class
    {
        return _queryDispatcher.QueryAsync(query, cancellationToken);
    }
}