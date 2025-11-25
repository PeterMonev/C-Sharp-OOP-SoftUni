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
    public class FileApender : BaseAppender
    {
        private readonly string _path;

        public FileApender(IFormatter<LogMessage> formatter, string path)
            : base(formatter)
        {

            this._path = ValidatePath(path);
        }

        public FileApender(IFormatter<LogMessage> formatter, ReportLevel reportThreshold, string path)
            : base(formatter, reportThreshold)
        {
            this._path = ValidatePath(path);
        }

        protected override void Append(string logMessage)
        {

            using StreamWriter write = File.AppendText(this._path);
            write.WriteLine(logMessage);
        }

        private static string ValidatePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be empty", nameof(path));
            }

            if (Path.IsPathFullyQualified(path))
            {
                throw new ArgumentException("Path cannot be empty", nameof(path));
            }

            return path;
        }
    }
}
