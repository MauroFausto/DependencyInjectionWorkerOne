using DependencyInjectionWorker_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionWorker_2.Logger
{
    /**
     * A implementação da interface IMessageWriter pode ser melhorada através da
     * API de logging embutida no .NET
     */

    public class LoggingMessageWriter : IMessageWriter
    {
        private readonly ILogger<LoggingMessageWriter> _logger;

        public LoggingMessageWriter(ILogger<LoggingMessageWriter> logger) => _logger = logger;

        public void Write(string message) => _logger.LogInformation("Info: {Msg}", message);
    }
}
