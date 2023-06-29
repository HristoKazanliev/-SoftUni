
namespace Logger
{ 
    using System;
    using Layouts;
    using Appenders;
    using ReportLevels;
    using LogFiles;
    using Loggers;
    using Logger.Factories;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //ILayout layout = new SimpleLayout();
            //IAppender appender = new ConsoleAppender(layout);
            //appender.ReportLevel = ReportLevel.Info;

            //ILogFile logFile = new LogFile();
            //IAppender appender1 = new FileAppender(layout, logFile);

            //var logger = new Logger(appender, appender1);
            //logger.Error("Error parsing JSON.");
            //logger.Info("User Pesho successfully registered.");

            List<IAppender> appenders = new List<IAppender>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] appenderArr = Console.ReadLine().Split();
                string appenderType = appenderArr[0];
                string layoutType = appenderArr[1];
                ReportLevel reportLevel = appenderArr.Length == 3 ? Enum.Parse<ReportLevel>(appenderArr[2], true) : ReportLevel.Info;

                ILayout layout = LayoutFactory.CreateLayout(layoutType);
                IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders.ToArray());

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] messageInfo = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                ReportLevel reportLevel = Enum.Parse<ReportLevel>(messageInfo[0], true);
                //DateTime dateTime = DateTime.Parse(messageInfo[1]);
                string message = messageInfo[2];

                if (reportLevel == ReportLevel.Fatal)
                {
                    logger.Fatal(message);
                }
                else if(reportLevel == ReportLevel.Critical)
                {
                    logger.Critical(message);
                }
                else if (reportLevel == ReportLevel.Error)
                {
                    logger.Error(message);
                }
                else if (reportLevel == ReportLevel.Warning)
                {
                    logger.Warning(message);
                }
                else
                {
                    logger.Info(message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Logger info");
            foreach (var appender in logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
