using System;
using System.Threading.Tasks;
using Common.Bus.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Service.Orders.Producer;

namespace Service.Orders.Consumers;

public class RandomCustomerPostedEventConsumer : IConsumer<RandomCustomerPostedEvent>
{
    private readonly ICustomersStorage _customers;
    private readonly ILogger<RandomCustomerPostedEventConsumer> _logger;

    public RandomCustomerPostedEventConsumer(ILogger<RandomCustomerPostedEventConsumer> logger,
        ICustomersStorage customers)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _customers = customers;
    }

    public async Task Consume(ConsumeContext<RandomCustomerPostedEvent> context)
    {
        _logger.LogDebug("Got an event {CorrelationId} created at {CreatedAt}", context.Message.CorrelationId,
            context.Message.CreatedAt);
        _customers.Customers.Add(context.Message.Customer);
        await Task.CompletedTask;
    }
}