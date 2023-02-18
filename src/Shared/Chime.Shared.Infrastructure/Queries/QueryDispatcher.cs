using Chime.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Chime.Shared.Infrastructure.Queries;

internal sealed class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        where TResult : class
    {
        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);
        var method = handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync));
        if (method is null) throw new InvalidOperationException("Query handler is invalid");

        return await (method.Invoke(handler, new object[] { query, cancellationToken }) as Task<TResult>)!;
    }
}