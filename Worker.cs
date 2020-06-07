using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotnetCoreWorkerServiceTemplate
{
    public class Worker : BackgroundService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly ILogger<Worker> _logger;
        public Worker(IHostApplicationLifetime hostApplicationLifetime, ILogger<Worker> logger)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.Run(async () =>
        {
            try
            {
                // Implementation
            }
            catch (Exception ex) when (False(() => _logger.LogCritical(ex, "Fatal error")))
            {
                throw;
            }
            finally
            {
                _hostApplicationLifetime.StopApplication();
            }
        });

        private static bool False(Action action) { action(); return false; }
    }
}