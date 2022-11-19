using DependencyInjectionWorker_1.Interfaces;

namespace DependencyInjectionWorker_1
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

        /**
         * Ao usar o padrão de Injeção de Dependência, o programador:
         *   >> Não usa o tipo concreto: MessageWriter, apenas a interface MessageWriter
         *      que implementa o método. Isso torna qualquer modificação no escopo do 
         *      Worker-Service muito mais fácil.
         * 
         *   >> Além disso, o framework não cria uma instância da classe MessageWriter,
         *      fazendo com que a instância da classe concreta seja utilizada apenas 
         *      pelo contêiner de serviços.
         */
    }
}