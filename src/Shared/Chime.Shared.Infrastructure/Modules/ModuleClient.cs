using Chime.Shared.Abstractions.Modules;

namespace Chime.Shared.Infrastructure.Modules;

internal sealed class ModuleClient : IModuleClient // 55
{
    private readonly IModuleRegistry _moduleRegistry;
    private readonly IModuleSerializer _moduleSerializer;

    public ModuleClient(
        IModuleRegistry moduleRegistry,
        IModuleSerializer moduleSerializer
    )
    {
        _moduleRegistry = moduleRegistry;
        _moduleSerializer = moduleSerializer;
    }

    public Task SendAsync(string path, object request, CancellationToken cancellationToken = default)
    {
        return SendAsync<object>(path, request, cancellationToken);
    }

    public async Task<TResult> SendAsync<TResult>(string path, object request,
        CancellationToken cancellationToken = default) where TResult : class
    {
        var registration = _moduleRegistry.GetRequestRegistration(path);
        if (registration is null)
            throw new InvalidOperationException($"No action has been defined for path: '{path}'.");

        var receiverRequest = TranslateType(request, registration.RequestType);
        var result = await registration.Action(receiverRequest, cancellationToken);

        return result is null ? null : TranslateType<TResult>(result);
    }

    public async Task PublishAsync(object message, CancellationToken cancellationToken = default)
    {
        var module = message.GetModuleName();
        var key = message.GetType().Name;
        var registrations = _moduleRegistry
            .GetBroadcastRegistrations(key)
            .Where(r => r.ReceiverType != message.GetType());

        var tasks = new List<Task>();

        foreach (var registration in registrations)
        {
            var action = registration.Action;
            var receiverMessage = TranslateType(message, registration.ReceiverType);

            tasks.Add(action(receiverMessage, cancellationToken));
        }

        await Task.WhenAll(tasks);
    }

    private T TranslateType<T>(object value)
    {
        return _moduleSerializer.Deserialize<T>(_moduleSerializer.Serialize(value));
    }

    private object TranslateType(object value, Type type)
    {
        return _moduleSerializer.Deserialize(_moduleSerializer.Serialize(value), type);
    }
}