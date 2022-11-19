using DependencyInjectionWorker_0.Classes;

namespace DependencyInjectionWorker_0
{
    /** Caso de Estudo - Inje��o de Depend�ncia
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

        /** [ Inje��o de depend�ncia - Hard Coded - Inst�ncia da classe 'chumbada / est�tica' no c�digo ]
         * 
         *  A presente classe Worker est� criando uma depend�ncia direta com a classe MessageWriter. 
         *  Depend�ncias 'Hard Coded' ou 'chumbadas' no c�digo s�o problem�ticas, e deveriam ser evitadas 
         *  a todo custo pelos seguintes motivos:
         *  
         *      1.  Ao remanejar a implementa��o da classe MessageWriter, criar�amos uma necessidadede modificar 
         *      a classe dependente - Worker, que tamb�m deveria ser re-implementada utilizando outra l�gica;
         *  
         *      2.  Caso a classe MessageWriter tamb�m possua depend�ncias, estas tamb�m dever�o ser configuradas 
         *      na classe Worker. Num projeto maior com m�ltiplas classes e m�ltiplas depend�ncias, a configura��o 
         *      do funcionamento do algoritmo ficaria espalhada pelo c�digo do projeto;
         *      
         *      3.  Essa implementa��o torna a execu��o de testes unit�rios dif�cil. No contexto de um roteiro de testes
         *      o aplicativo deveria realizar um mock ou um stub dessa classe, por�m, com essa implementa��o, isso n�o � poss�vel.
         *      
         *  Tais problemas podem ser solucionados da seguinte forma:
         *  
         *      A.  Utilizar uma interface ou uma classe base para abstrair a implementa��o da depend�ncia;
         *      
         *      B.  Registrar a depend�ncia em um cont�iner de servi�os. .NET prov� uma interface de servi�o de cont�ineres,
         *      atrav�s da interface IServiceProvider. Os servi�os s�o tipicamente inicializados pelo arquivo de StartUp da aplica��o,
         *      sendo acrescentados a uma interface IServiceCollection. Uma vez que todos os servi�os s�o inclu�dos, � poss�vel
         *      utilizar o m�todo que compila esse cont�iner de servi�os: BuildServiceProvider.
         *      
         *      C.  � poss�vel tamb�m injetar o servi�o no m�todo construtor da classe onde o mesmo ser� utilizado. O .NET se encarrega
         *      de criar uma inst�ncia da classe-depend�ncia e, posteriormente, quando n�o for mais utilizada, realizar seu descarte.
         * 
         */
    }
}