using System;
using System.Threading.Tasks;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Microsoft.Extensions.Logging;
using Service.Orders.Producer;

namespace Service.Orders.EventHandlers
{
    public class RandomCatalogItemsPostedEventEventHandler : IIntegrationEventHandler<RandomCatalogItemsPostedEvent>
    {
        private readonly ICatalogItemsStorage _catalogItems;
        private readonly ILogger<RandomCatalogItemsPostedEventEventHandler> _logger;


        public RandomCatalogItemsPostedEventEventHandler(ILogger<RandomCatalogItemsPostedEventEventHandler> logger,
            ICatalogItemsStorage catalogItems)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _catalogItems = catalogItems;
        }

        public async Task Handle(RandomCatalogItemsPostedEvent request)
        {
            _logger.LogTrace($"Got an event {request.Id} created at {request.CreationDate}");
            _catalogItems.Items.Add(request.Items);
            await Task.CompletedTask;
        }
    }
}