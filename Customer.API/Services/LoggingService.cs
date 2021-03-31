using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Services
{
    public interface ILoggingService
    {
        void LogInformation(string message, params object[] parameters);
    }

    public class LoggingService : ILoggingService
    {
        private readonly ILogger _logger;
        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message, params object[] parameters)
        {
            _logger.LogInformation(message, parameters);
        }
    }
}
