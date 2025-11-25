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
            int n = int.Parse(Console.ReadLine());
            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < appenders.Length; i++)
            {
                string[] data = Console.ReadLine().Split();

                IFormatter<LogMessage> formatter = CreateFormatter(data[1]);
                ReportLevel reportThreshold = ReportLevel.Info;

                if (data.Length > 3)
                {
                    reportThreshold = Enum.Parse<ReportLevel>(data[2], ignoreCase: true);
                }
                appenders[i] = CreateAppender(data[0], formatter, reportThreshold);

            }

            ILogger logger = new Logger(appenders.ToImmutableArray());
            ProcessMessages(logger);

            Console.WriteLine(logger);
        }

        private static void ProcessMessages(ILogger logger)
        {
            string input;
            while((input= Console.ReadLine()) != "END")
            {
                string[] data = input.Split("|");
                ReportLevel reportLevel = Enum.Parse<ReportLevel>(data[0], ignoreCase: true);
                string time = data[1];
                string message = data[2];

                logger.Log(time, reportLevel, message);
            }
        }

        private static IFormatter<LogMessage> CreateFormatter(string type)
        {
            if (type == "SimpleLayout") return new SimpleLogMessageFormatter();

            if (type == "XmlLayout") return new XMLLogMessageFormatter();

            if (type == "JsonLayout") return new JsonLogMessageFormatter();

            throw new InvalidOperationException("Invalid formatter type.");
        }

        private static IAppender CreateAppender(string type, IFormatter<LogMessage> formatter, ReportLevel reportThreshold)
        {
            if (type == "ConsoleAppender") return new ConsoleAppender(formatter, reportThreshold);

            if (type == "FileAppender") return new FileApender(formatter, reportThreshold, "D:/Coding Programm/Repos/C# OPP/Exercises - SOLID/all_logs.txt");

            throw new InvalidOperationException("Invalid formatter type.");
        }

        private static void Demo()
        {

            IFormatter<LogMessage> simpleFormatter = new SimpleLogMessageFormatter();
            IFormatter<LogMessage> xmlFormatter = new XMLLogMessageFormatter();
            IFormatter<LogMessage> jsonFormatter = new JsonLogMessageFormatter();

            IAppender consoleAppender = new ConsoleAppender(jsonFormatter);

            IAppender verboseFileAppender = new FileApender(simpleFormatter, "D:/Coding Programm/Repos/C# OPP/Exercises - SOLID/all_logs.txt");

            IAppender criticalFIleAppender = new FileApender(xmlFormatter, ReportLevel.Error, "D:/Coding Programm/Repos/C# OPP/Exercises - SOLID/all_logs.txt");

            IImmutableList<IAppender> appenders = (new[] { consoleAppender, verboseFileAppender, criticalFIleAppender }).ToImmutableArray();
            ILogger logger = new Logger(appenders);

            logger.Log("3/26/2015 2:08:11 PM", ReportLevel.Error, "Errorparsing JSON.");
            logger.Log("3/26/2015 2:08:11 PM", ReportLevel.Info, "User Peshosuccessfully registered.");
        }
    }
}
