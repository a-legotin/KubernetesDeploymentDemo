using System;
using System.Threading;
using System.Threading.Tasks;
using Bus.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Posts.RandomSource
{
    public class RandomPostsService : BackgroundService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<RandomPostsService> _logger;

        public RandomPostsService(ILogger<RandomPostsService> logger,
            IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _eventBus.Publish(new IntegrationEvent());
                await Task.Delay(100, stoppingToken);
            }
        }
    }
}