using DependencyInjectionWorker_2;
using DependencyInjectionWorker_2.Classes;
using DependencyInjectionWorker_2.Interfaces;
using DependencyInjectionWorker_2.Logger;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>()
            .AddScoped<IMessageWriter, LoggingMessageWriter>();
    })
    .Build();

/**
 * O m�todo configurador de servi�os registra a nova interface IMessageWriter
 * implementando o tipo concreto LoggingMessageWriter.
 */

await host.RunAsync();


