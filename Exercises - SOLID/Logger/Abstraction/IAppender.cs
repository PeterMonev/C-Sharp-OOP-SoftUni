
using Logger.Models;

namespace Logger.Abstraction
{
    public interface IAppender
    {
        void Append(LogMessage logMessage);
    }
}
