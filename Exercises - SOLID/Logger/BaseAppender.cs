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
    public abstract class BaseAppender : IAppender
    {
        private IFormatter<LogMessage> _formatter;
        private readonly ReportLevel _reportThreshold;

        protected BaseAppender(IFormatter<LogMessage> formatter)
            : this(formatter, ReportLevel.Info)
        {
   
        }
        protected BaseAppender(IFormatter<LogMessage> formatter, ReportLevel reportThreshold)
        {
            this._formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            this._reportThreshold = reportThreshold; 
        }
        public void Append(LogMessage logMessage)
        {
            if(logMessage.ReportLevel < this._reportThreshold)
            {
                return;
            }

            string textToAppend = this._formatter.Format(logMessage);
            this.Append(textToAppend);
        }

        protected abstract void Append(string logMessage);
    }
}
 