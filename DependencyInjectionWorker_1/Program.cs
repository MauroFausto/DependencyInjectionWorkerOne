using DependencyInjectionWorker_1;
using DependencyInjectionWorker_1.Classes;
using DependencyInjectionWorker_1.Interfaces;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>()
            .AddScoped<IMessageWriter, MessageWriter>();
    })
    .Build();

await host.RunAsync();

/** 
 *  O c�digo exemplificado aqui, registra a interface de servi�o IMessageWriter 
 *  com o tipo concreto MessageWriter. O m�todo 'AddScoped' registra o servi�o com
 *  um ciclo de vida 'scoped' - no escopo, ou seja, sua exist�ncia � delimitada pela
 *  sua requisi��o � execu��o e sua resposta.
 */
