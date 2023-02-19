namespace Chime.Shared.Infrastructure.Postgres;

public class UnitOfWorkTypeRegistry
{
    private readonly Dictionary<string, Type> _types = new();

    public void Register<T>() where T : IUnitOfWork
    {
        _types[GetKey<T>()] = typeof(T);
    }

    public Type Resolve<T>()
    {
        return _types.TryGetValue(GetKey<T>(), out var type) ? type : null;
    }

    private static string GetKey<T>()
    {
        return $"{typeof(T).GetModuleName()}";
    }
}