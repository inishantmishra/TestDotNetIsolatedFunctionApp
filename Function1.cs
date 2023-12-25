using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TestFuntionApp
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("MyScheduler")]
        public async Task MyScheduler([TimerTrigger("%MyScheduler%")] TimerInfo timer)
        {
            try
            {
                _logger.LogInformation("{Message}", $"Schedular started at {DateTime.UtcNow}.");

                // Do the process

                _logger.LogInfoWithNoSampling("{Message}", $"Scheduler: completed at {DateTime.UtcNow}.");
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithNoSampling(ex, "Schedular Exception: scheduler failed to complete at {Message}.", DateTime.UtcNow);
            }
        }
    }
}
