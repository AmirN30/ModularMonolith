using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModularMonolith.Shared.Abstractions.Modules;

namespace ModularMonolith.Shared.Infrastructure.Messaging
{
    internal sealed class AsynchronousDispatcherJob : BackgroundService
    {
        private readonly IMessageChannel _channel;
        private readonly IModuleClient _moduleClient;
        private readonly ILogger<AsynchronousDispatcherJob> _logger;
        
        public AsynchronousDispatcherJob(IMessageChannel channel, IModuleClient moduleClient, ILogger<AsynchronousDispatcherJob> logger)
        {
            _channel = channel;
            _moduleClient = moduleClient;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Running asynchronous dispatcher job");

            await foreach (var message in _channel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await _moduleClient.PublishAsync(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
            
            _logger.LogInformation("Finished running asynchronous dispatcher job");
        }
    }
}