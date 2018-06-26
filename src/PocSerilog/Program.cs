using System;
using Serilog;
using Serilog.Formatting.Compact;

namespace TSundvall.DotnetCoreDevExp.PocSerilog
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(new CompactJsonFormatter(), "log.clef")
            .CreateLogger();

            Log.Information("Logging an item number {ItemNumber}", 250);
            Log.Information($"Loggin an item number {350}");

            Log.CloseAndFlush();
        }
    }
}
