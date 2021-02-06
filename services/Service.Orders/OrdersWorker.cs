using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Common.Core.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Service.Orders
{
    public class OrdersWorker : BackgroundService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<OrdersWorker> _logger;

        public OrdersWorker(ILogger<OrdersWorker> logger, IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogTrace("Worker running at: {time}", DateTimeOffset.Now);
                _eventBus.Publish(new OrderPostedEvent
                {
                    Order = new Order
                    {
                        Guid = Guid.NewGuid()
                    }
                });
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}