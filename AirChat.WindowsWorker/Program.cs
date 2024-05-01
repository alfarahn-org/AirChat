using Microsoft.Extensions.Hosting;
using AirChat.WindowsWorker;

var builder = Host.CreateDefaultBuilder(args)
    .UseWindowsService() // This line is important
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    });

var host = builder.Build();
host.Run();