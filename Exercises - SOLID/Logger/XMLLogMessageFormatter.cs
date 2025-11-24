using Logger.Abstraction;
using Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class XMLLogMessageFormatter : IFormatter<LogMessage>
    {
        public string Format(LogMessage value)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"   <time>{value.Time}</time>");
            sb.AppendLine($"   <lvele>{value.ReportLevel.ToString()}</level>");
            sb.AppendLine($"   <message>{value.Message}</message>");
            sb.AppendLine("</log>");

            return sb.ToString();

        }
    }
}
