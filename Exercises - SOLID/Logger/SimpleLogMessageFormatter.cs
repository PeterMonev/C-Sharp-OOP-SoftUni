using Logger.Abstraction;
using Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class SimpleLogMessageFormatter : IFormatter<LogMessage>
    {
        public string Format(LogMessage value)
        {
            return $"{value.Time} - {value.ReportLevel.ToString().ToUpper()} - {value.Message}";
        }
    }
}
