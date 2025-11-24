using Logger.Enums;

namespace Logger.Models
{
    public class LogMessage
    {
        public LogMessage(string time, ReportLevel reportLevel, string message)
        {
            Time = time;
            ReportLevel = reportLevel;
            Message = message;
        }

        public string Time { get; }
        public ReportLevel ReportLevel { get; }
        public string Message { get; }

    
    }
}
