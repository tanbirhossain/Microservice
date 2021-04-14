using Microsoft.Extensions.Logging;


namespace Product.API.Services
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
