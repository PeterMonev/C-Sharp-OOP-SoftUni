using Logger.Abstraction;
using Logger.Enums;
using Logger.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger : ILogger
    {
        private readonly IImmutableList<IAppender> _appenders;
        public Logger(IImmutableList<IAppender> appenders)
        {
            this._appenders = appenders ?? throw new ArgumentNullException(nameof(appenders));
        }
        public void Log(string time, ReportLevel reportLevel, string message)
        {
            foreach(IAppender appender in this._appenders)
            {
                LogMessage logMessage = new LogMessage(time, reportLevel, message);
                appender.Append(logMessage);
            }
        }
        
    }
}
