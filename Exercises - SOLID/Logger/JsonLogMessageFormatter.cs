using Logger.Abstraction;
using Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public  class JsonLogMessageFormatter : IFormatter<LogMessage>
    {

        public string Format(LogMessage value)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine($"   \"time\": \"{value.Time}\",");
            sb.AppendLine($"   \"time\": \"{value.ReportLevel}");
            sb.AppendLine($"   \"messsage\": \"{value.Message}\"");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
