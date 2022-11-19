using DependencyInjectionWorker_2.Interfaces;

namespace DependencyInjectionWorker_2
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMessageWriter _messageWriter;

        public Worker(ILogger<Worker> logger,
            IMessageWriter messageWriter)
        {
            _logger = logger;
            _messageWriter = messageWriter;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _messageWriter.Write($"Worker writing with MessageWriter class at: {DateTimeOffset.Now} ");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}