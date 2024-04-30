using Microsoft.AspNetCore.SignalR;

namespace AirChat.API
{
    public class FlightWorker : BackgroundService
    {
        private readonly ILogger<FlightWorker> _logger;
        private readonly IHubContext<FlightHub> _flightHub;

        public FlightWorker(ILogger<FlightWorker> logger, IHubContext<FlightHub> flightHub)
        {
            _logger = logger;
            _flightHub = flightHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _flightHub.Clients.All.SendAsync("SendFlightCoordinate", "Hello From Worker : " + DateTime.Now);
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    await Console.Out.WriteLineAsync("test worker");
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
