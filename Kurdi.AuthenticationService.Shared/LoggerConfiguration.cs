

using NLog;
using NLog.Conditions;
using NLog.Targets;
using NLog.Extensions.Logging;

namespace Kurdi.AuthenticationService.Shared
{
    public static class LoggerConfiguration
    {
        public static LogFactory GetSimpleLogger()
        {
           // Logger logger = LogManager.GetCurrentClassLogger();
            return LogManager.LogFactory;

        }
        public static Logger GetColeredConsoleLogger()
        {
            var targetConfiguration = new NLog.Targets.ColoredConsoleTarget();
            // targetConfiguration.Name = "coloredConsolee";

            var highlightRule = new ConsoleRowHighlightingRule();
            highlightRule.Condition = ConditionParser.ParseExpression("level == LogLevel.Info");
            highlightRule.ForegroundColor = ConsoleOutputColor.Green;
            targetConfiguration.RowHighlightingRules.Add(highlightRule);



            var loggerConfig = new NLog.Config.LoggingConfiguration();

            // Rules for mapping loggers to targets            
            loggerConfig.AddRule(LogLevel.Info, LogLevel.Fatal, targetConfiguration);

            // Apply config           
            NLog.LogManager.Configuration = loggerConfig;


            var logger = NLog.LogManager.GetCurrentClassLogger();
            return logger;

        }

        public static void GetFileLogger()
        {
            // var consoleTarget = new NLog.Targets.ColoredConsoleTarget();
            // consoleTarget.Name = "coloredConsole";

            // var highlightRule = new ConsoleRowHighlightingRule();
            // highlightRule.Condition = ConditionParser.ParseExpression("level == LogLevel.Info");
            // highlightRule.ForegroundColor = ConsoleOutputColor.Green;
            // consoleTarget.RowHighlightingRules.Add(highlightRule);




            // var config = new NLog.Config.LoggingConfiguration();

            // // Targets where to log to: File and Console
            // var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            // var logconsole = new NLog.Targets.ConsoleTarget("logconsole");


            // // Rules for mapping loggers to targets            
            // config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            // config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            // config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);


            // // Apply config           
            // NLog.LogManager.Configuration = config;

            // NLog.LogManager.Setup().LoadConfiguration(builder =>
            // {
            //     builder.ForLogger().FilterMinLevel(LogLevel.Info).WriteToConsole();
            //     builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToFile(fileName: "file.txt");
            // });

            // var logger = NLog.LogManager.GetLogger("coloredConsole");
            // logger.Info("Message with {myProperty}", "myValue");
            // return logger;

        }

    }
}