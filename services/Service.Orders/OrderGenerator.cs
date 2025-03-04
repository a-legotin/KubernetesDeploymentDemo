using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Bus.Events;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service.Orders.Producer;

namespace Service.Orders;

public class OrderGenerator : BackgroundService
{
    private readonly IBus _bus;
    private readonly ILogger<OrderGenerator> _logger;
    private readonly IOrderProducerFactory _orderProducerFactory;

    public OrderGenerator(ILogger<OrderGenerator> logger,
        IOrderProducerFactory orderProducerFactory,
        IBus bus)
    {
        _logger = logger;
        _orderProducerFactory = orderProducerFactory;
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogDebug("Orders generator running at: {Time}", DateTimeOffset.Now);
            await _bus.Publish(new RandomCustomerRequest(), stoppingToken);
            await _bus.Publish(new RandomCatalogItemsRequest(), stoppingToken);

            var order = _orderProducerFactory.Construct(stoppingToken).GetNextOrder();
            if (order != null)
            {
                await _bus.Publish(new OrderPostedEvent
                {
                    Order = order
                }, stoppingToken);
                _logger.LogDebug("Created order {CustomerGuid} for {CustomerName}", order.Guid, order.Customer);
            }

            await Task.Delay(TimeSpan.FromMinutes(3), stoppingToken);
        }
    }
}