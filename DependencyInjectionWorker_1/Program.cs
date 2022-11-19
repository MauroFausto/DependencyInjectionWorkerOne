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
 *  O código exemplificado aqui, registra a interface de serviço IMessageWriter 
 *  com o tipo concreto MessageWriter. O método 'AddScoped' registra o serviço com
 *  um ciclo de vida 'scoped' - no escopo, ou seja, sua existência é delimitada pela
 *  sua requisição à execução e sua resposta.
 */
