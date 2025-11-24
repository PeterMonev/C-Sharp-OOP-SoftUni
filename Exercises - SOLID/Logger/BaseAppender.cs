using Logger.Abstraction;
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
        protected BaseAppender(IFormatter<LogMessage> formatter)
        {
            this._formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }
        public void Append(LogMessage logMessage)
        {
            string textToAppend = this._formatter.Format(logMessage);
            this.Append(textToAppend);
        }

        protected abstract void Append(string logMessage);
    }
}
