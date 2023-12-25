using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TestFuntionApp
{
    public class ServiceBusTriggeredFunction
    {
        private readonly ILogger<ServiceBusTriggeredFunction> _logger;

        public ServiceBusTriggeredFunction(ILogger<ServiceBusTriggeredFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ServiceBusTriggeredFunction))]
        public void Run([ServiceBusTrigger("%MyServiceQueue%", Connection = "ServiceBusConnection")] string myQueueItem)
        {
            try
            {
                _logger.LogInformation("Message received - {message}", myQueueItem);

                // Do the Process

                _logger.LogInformation("Message processed successfully : {message}", myQueueItem);

            }
            catch (Exception ex)
            {
                _logger.LogErrorWithNoSampling(ex, "Error occured while processing message - {QueueItem}", myQueueItem);
                throw;
            }
        }
    }
}
