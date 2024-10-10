using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Smz.Practice.TestHost;

class MyService : IHostedService
{
    private readonly ITest test;
    private readonly IConfiguration configuration;
    private readonly ILogger<MyService> logger;
    public string ProcessorKey { get; init; } = "PROCESSOR_IDENTIFIER";

    public MyService(ITest test, IConfiguration configuration, ILogger<MyService> logger)
    {
        this.test = test;
        this.configuration = configuration;
        this.logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        string message = configuration.GetValue<string>("message") ?? string.Empty;
        message += $"\n{configuration.GetValue<string>(ProcessorKey) ?? string.Empty}";
        logger?.LogInformation($"Sending {message}");

        await test.InvokeEndpointAsync(EndpointType.Pokemon);
        test.Run(message);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
