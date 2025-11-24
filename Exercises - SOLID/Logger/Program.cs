using Logger.Models;
using Logger.Abstraction;
using System.Collections.Immutable;
using Logger.Enums;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            //IFormatter<LogMessage> formatter = new SimpleLogMessageFormatter();
            //IFormatter<LogMessage> formatter = new XMLLogMessageFormatter();
            IFormatter<LogMessage> formatter = new JsonLogMessageFormatter();

            IAppender consoleAppender = new ConsoleAppender(formatter);

            IImmutableList<IAppender> appenders = (new[] { consoleAppender }).ToImmutableArray();
            ILogger logger = new Logger(appenders);

            logger.Log("3/26/2015 2:08:11 PM", ReportLevel.Error, "Errorparsing JSON.");
            logger.Log("3/26/2015 2:08:11 PM", ReportLevel.Info, "User Peshosuccessfully registered.");
        }
    }
}
