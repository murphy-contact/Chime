using Chime.Shared.Abstractions.Commands;
using Chime.Shared.Abstractions.Events;
using Chime.Shared.Abstractions.Queries;

namespace Chime.Shared.Abstractions.Dispatchers;

public interface IDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;

    Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent;


    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        where TResult : class;
}