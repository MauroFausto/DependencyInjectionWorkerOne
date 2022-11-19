using DependencyInjectionWorker_0.Classes;

namespace DependencyInjectionWorker_0
{
    /** Caso de Estudo - Injeção de Dependência
     *  
     *  Fonte: https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection
     *  
     */

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly MessageWriter _messageWriter = new MessageWriter();

        public Worker(ILogger<Worker> logger,
                      MessageWriter messageWriter)
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

        /** [ Injeção de dependência - Hard Coded - Instância da classe 'chumbada / estática' no código ]
         * 
         *  A presente classe Worker está criando uma dependência direta com a classe MessageWriter. 
         *  Dependências 'Hard Coded' ou 'chumbadas' no código são problemáticas, e deveriam ser evitadas 
         *  a todo custo pelos seguintes motivos:
         *  
         *      1.  Ao remanejar a implementação da classe MessageWriter, criaríamos uma necessidadede modificar 
         *      a classe dependente - Worker, que também deveria ser re-implementada utilizando outra lógica;
         *  
         *      2.  Caso a classe MessageWriter também possua dependências, estas também deverão ser configuradas 
         *      na classe Worker. Num projeto maior com múltiplas classes e múltiplas dependências, a configuração 
         *      do funcionamento do algoritmo ficaria espalhada pelo código do projeto;
         *      
         *      3.  Essa implementação torna a execução de testes unitários difícil. No contexto de um roteiro de testes
         *      o aplicativo deveria realizar um mock ou um stub dessa classe, porém, com essa implementação, isso não é possível.
         *      
         *  Tais problemas podem ser solucionados da seguinte forma:
         *  
         *      A.  Utilizar uma interface ou uma classe base para abstrair a implementação da dependência;
         *      
         *      B.  Registrar a dependência em um contêiner de serviços. .NET provê uma interface de serviço de contêineres,
         *      através da interface IServiceProvider. Os serviços são tipicamente inicializados pelo arquivo de StartUp da aplicação,
         *      sendo acrescentados a uma interface IServiceCollection. Uma vez que todos os serviços são incluídos, é possível
         *      utilizar o método que compila esse contêiner de serviços: BuildServiceProvider.
         *      
         *      C.  É possível também injetar o serviço no método construtor da classe onde o mesmo será utilizado. O .NET se encarrega
         *      de criar uma instância da classe-dependência e, posteriormente, quando não for mais utilizada, realizar seu descarte.
         * 
         */
    }
}