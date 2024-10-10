using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Serilog;

namespace Smz.Practice.TestHost;
class Program
{
    static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
            .WaitAndRetryAsync(3, retry => TimeSpan.FromSeconds(Math.Pow(2, retry)));
    }

    static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File("test.log")
            .CreateLogger();

        HostBuilder hostBuilder = new();
        
        hostBuilder.ConfigureServices((context, services) => {
            services.AddSingleton<ITest, Test>();
            services.AddSingleton<IHostedService, MyService>();
            services.AddHttpClient<ITest, Test>(client => {
                client.BaseAddress = new Uri("https://pokeapi.co");
            }).AddPolicyHandler(GetRetryPolicy());
        });
        
        hostBuilder.ConfigureAppConfiguration((context, config) => {
            config.AddCommandLine(args);
            config.AddEnvironmentVariables();
        });
        
        hostBuilder.ConfigureLogging((context, logging) => {
            logging.AddConsole();
            logging.AddSerilog();
        });
        
        await hostBuilder.RunConsoleAsync();
    }
}