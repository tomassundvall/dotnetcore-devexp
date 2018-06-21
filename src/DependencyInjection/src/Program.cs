using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace TSundvall.DotnetCoreDevExp.DependencyInjection
{
    public class Program
    {
        static void Main(string[] args)
        {
            var webbHost = new WebHostBuilder()
                .UseKestrel(opt =>
                {
                    opt.Listen(IPAddress.Any, 5001);
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
                })                
                .UseSerilog((hostingContext, config) =>
                {
                    config.ReadFrom.Configuration(hostingContext.Configuration);
                    config.Enrich.FromLogContext();
                })
                .UseStartup<Startup>()
                .Build();

            webbHost.Run();
        }
    }
}