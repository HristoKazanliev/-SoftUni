using System;
using System.Collections.Generic;
using System.Text;
using Logger.Layouts;
using Logger.ReportLevels;

namespace Logger.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}
