using Logger.Models;

namespace Logger.Abstraction
{
    public interface IFormatter<T>
    {
        string Format(T logMessage);
    }
}
