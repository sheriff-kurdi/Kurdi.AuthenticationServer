using Kurdi.AuthenticationService.Shared;
using NLog;

internal class Program
{
    private static void Main(string[] args)
    {
        
        Logger logger = LoggerConfiguration.GetColeredConsoleLogger();
        
        logger.Info("hiiiiiii");
        Console.WriteLine("Hello, World!");
    }
}