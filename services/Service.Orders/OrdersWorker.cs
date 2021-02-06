using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service.Orders.Producer;

namespace Service.Orders
{
    public class OrdersWorker : BackgroundService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<OrdersWorker> _logger;
        private readonly IOrderProducerFactory _orderProducerFactory;

        public OrdersWorker(ILogger<OrdersWorker> logger,
            IEventBus eventBus,
            IOrderProducerFactory orderProducerFactory)
        {
            _logger = logger;
            _eventBus = eventBus;
            _orderProducerFactory = orderProducerFactory;
            eventBus.Subscribe<RandomCustomerPostedEvent, IIntegrationEventHandler<RandomCustomerPostedEvent>>();
            eventBus
                .Subscribe<RandomCatalogItemsPostedEvent, IIntegrationEventHandler<RandomCatalogItemsPostedEvent>>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogTrace("Worker running at: {time}", DateTimeOffset.Now);
                _eventBus.Publish(new RandomCustomerRequest());
                _eventBus.Publish(new RandomCatalogItemsRequest());

                var order = _orderProducerFactory.Construct(stoppingToken).GetNextOrder();
                if (order == null)
                    continue;
                _eventBus.Publish(new OrderPostedEvent
                {
                    Order = order
                });
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}