using Chime.Shared.Abstractions.Messaging;

namespace Chime.Shared.Infrastructure.Outbox;

internal sealed class OutboxTypeRegistry
{
    private readonly Dictionary<string, Type> _types = new();

    public void Register<T>() where T : IOutbox
    {
        _types[GetKey<T>()] = typeof(T);
    }

    public Type Resolve(IMessage message)
    {
        return _types.TryGetValue(GetKey(message.GetType()), out var type) ? type : null;
    }

    private static string GetKey<T>()
    {
        return GetKey(typeof(T));
    }

    private static string GetKey(Type type)
    {
        return type.IsGenericType
            ? $"{type.GenericTypeArguments[0].GetModuleName()}"
            : $"{type.GetModuleName()}";
    }
}