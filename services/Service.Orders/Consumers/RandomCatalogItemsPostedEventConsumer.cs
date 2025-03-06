using System;
using System.Threading.Tasks;
using Common.Bus.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Service.Orders.Producer;

namespace Service.Orders.Consumers;

internal class RandomCatalogItemsPostedEventConsumer : IConsumer<RandomCatalogItemsPostedEvent>
{
    private readonly ICatalogItemsStorage _catalogItems;
    private readonly ILogger<RandomCatalogItemsPostedEventConsumer> _logger;


    public RandomCatalogItemsPostedEventConsumer(ILogger<RandomCatalogItemsPostedEventConsumer> logger,
        ICatalogItemsStorage catalogItems)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _catalogItems = catalogItems;
    }

    public async Task Consume(ConsumeContext<RandomCatalogItemsPostedEvent> context)
    {
        _logger.LogDebug("Got an event {CorrelationId} created at {CreatedAt}", context.Message.CorrelationId,
            context.Message.CreatedAt);
        _catalogItems.Items.Add(context.Message.Items);
        await Task.CompletedTask;
    }
}