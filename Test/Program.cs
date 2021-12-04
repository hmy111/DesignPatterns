
Client client = new Client();
client.GetYear();


[Decorator(typeof(ITimeProvider))]
public class Client
{
    public int GetYear()
    {
        ITimeProvider provider = AttributeHelper.Injector<ITimeProvider>(this) ?? throw new NullReferenceException();

        return provider.CurrentDate.Year;
    }
}
sealed class DecoratorAttribute : Attribute
{
    public readonly object Injector;
    private readonly Type _type;
    public DecoratorAttribute(Type type)
    {
        _type = type;
        Injector = new Assembler().Create(_type);
    }
    public Type @Type => this._type;
}

static class AttributeHelper
{
    /// <summary>
    /// target:" 客户端
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static T? Injector<T>(object target) where T : class
    {
        if (target == null) throw new ArgumentNullException();

        var attributes = target.GetType().GetCustomAttributes(typeof(DecoratorAttribute), false);

        if (attributes.Length <= 0) return null;

        foreach (var attr in (DecoratorAttribute[])attributes)
        {
            if (attr.Type == typeof(T))
            {
                return (T?)attr.Injector;
            }
        }
        return null;
    }
}

internal class Assembler
{
    private static Dictionary<Type, Type> _cache = new Dictionary<Type, Type>();

    static Assembler()
    {
        _cache.Add(typeof(ITimeProvider), typeof(TimeProvider));
    }

    public object Create(Type type)
    {
        if (type == null || !_cache.ContainsKey(type)) throw new ArgumentNullException();

        Type traget = _cache[type];
        return Activator.CreateInstance(traget)!;
    }

    public T Create<T>()
    {
        return (T)Create(typeof(T));
    }
}

public interface ITimeProvider
{
    DateTime CurrentDate { get; }
}

public class TimeProvider : ITimeProvider
{
    public DateTime CurrentDate => DateTime.Now;
}