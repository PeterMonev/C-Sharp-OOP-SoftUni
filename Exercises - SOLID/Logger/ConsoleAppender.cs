using Logger.Abstraction;
using Logger.Enums;
using Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class ConsoleAppender : BaseAppender
    {
        public ConsoleAppender(IFormatter<LogMessage> formatter) : base(formatter)
        {
        }

        public ConsoleAppender(IFormatter<LogMessage> formatter, ReportLevel reportThreshold) : base(formatter, reportThreshold)
        {
        }
        protected override void Append(string logMessage)
        {
           Console.Write(logMessage);
        }
    }
}
