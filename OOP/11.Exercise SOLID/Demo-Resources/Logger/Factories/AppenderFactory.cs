namespace Logger.Factories
{
    using System;

    using Appenders;
    using Layouts;
    using LogFiles;
    using ReportLevels;

    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, ReportLevel reportlevel = ReportLevel.Info)
        {
            IAppender appender = type switch
            {
                "FileAppender" => new FileAppender(layout, new LogFile(), "../../../log.txt"),
                "ConsoleAppender" => new ConsoleAppender(layout),
                _ => throw new InvalidOperationException("Invalid type!")
            };
            appender.ReportLevel = reportlevel;
            return appender;
        }
    }
}
