using System;
using System.Collections.Generic;
using System.Text;
using Logger.Appenders;

namespace Logger.Loggers
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Critical(string message);
        void Fatal(string message);
    }
}
