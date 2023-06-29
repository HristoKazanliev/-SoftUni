using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Logger.Layouts;
using Logger.LogFiles;
using Logger.ReportLevels;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logfile;
        private readonly string path;

        public FileAppender(ILayout layout, ILogFile logFile, string path) : base(layout)
        {
            this.logfile = logFile;
            this.path = path;
        }

        public override void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            string output = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
            this.logfile.Write(output);
            this.AppendedMessages++;
            File.AppendAllText(path, output);
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.logfile.Size}";
        }
    }
}
