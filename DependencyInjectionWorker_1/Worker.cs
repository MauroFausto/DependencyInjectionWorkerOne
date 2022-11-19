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
         * Ao usar o padr�o de Inje��o de Depend�ncia, o programador:
         *   >> N�o usa o tipo concreto: MessageWriter, apenas a interface MessageWriter
         *      que implementa o m�todo. Isso torna qualquer modifica��o no escopo do 
         *      Worker-Service muito mais f�cil.
         * 
         *   >> Al�m disso, o framework n�o cria uma inst�ncia da classe MessageWriter,
         *      fazendo com que a inst�ncia da classe concreta seja utilizada apenas 
         *      pelo cont�iner de servi�os.
         */
    }
}