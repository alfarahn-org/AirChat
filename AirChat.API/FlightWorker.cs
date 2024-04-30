namespace AirChat.API
{
    public class FlightWorker : BackgroundService
    {
        private readonly ILogger<FlightWorker> _logger;

        public FlightWorker(ILogger<FlightWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    await Console.Out.WriteLineAsync("test worker");
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
