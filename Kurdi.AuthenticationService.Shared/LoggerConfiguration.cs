

namespace Kurdi.AuthenticationService.Shared
{
    public class LoggerConfiguration
    {
        public void GetConsoleLogger()
        {
            var consoleTarget = new ColoredConsoleTarget();

            var highlightRule = new ConsoleRowHighlightingRule();
            highlightRule.Condition = ConditionParser.ParseExpression("level == LogLevel.Info");
            highlightRule.ForegroundColor = ConsoleOutputColor.Green;
            consoleTarget.RowHighlightingRules.Add(highlightRule);
        }
    }
}