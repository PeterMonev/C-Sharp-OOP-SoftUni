using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Abstraction
{
    public interface ILogger
    {
        void Log(string time, ReportLevel reportLevel, string message);

        //void Info(string time, string message);
        //void Warn(string time, string message);
        //void Error(string time, string message);
        //void Fatal(string time, string message);
    }
}
