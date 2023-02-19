namespace Chime.Shared.Infrastructure.Outbox;

internal sealed class InboxTypeRegistry
{
    private readonly Dictionary<string, Type> _types = new();

    public void Register<T>() where T : IInbox
    {
        _types[GetKey<T>()] = typeof(T);
    }

    public Type Resolve<T>()
    {
        return _types.TryGetValue(GetKey<T>(), out var type) ? type : null;
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