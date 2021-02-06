using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Api.Database.Repository;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.EventHandlers
{
    public class RandomCatalogItemsRequestEventHandler : IIntegrationEventHandler<RandomCatalogItemsRequest>
    {
        private readonly ICatalogItemsRepository _catalogItemsRepository;
        private readonly IEventBus _eventBus;
        private readonly ILogger<RandomCatalogItemsRequestEventHandler> _logger;
        private readonly IMapper _mapper;

        public RandomCatalogItemsRequestEventHandler(ILogger<RandomCatalogItemsRequestEventHandler> logger,
            ICatalogItemsRepository catalogItemsRepository,
            IEventBus eventBus,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _catalogItemsRepository = catalogItemsRepository;
            _eventBus = eventBus;
            _mapper = mapper;
        }

        public async Task Handle(RandomCatalogItemsRequest request)
        {
            _logger.LogTrace("Got random catalog items request");
            var catalogItemDtos = _catalogItemsRepository.GetAll().ToArray();
            var randomItems = catalogItemDtos.OrderBy(c => Guid.NewGuid())
                .Take(new Random(DateTime.Now.Millisecond).Next(2, 10))
                .ToArray();
            _eventBus.Publish(new RandomCatalogItemsPostedEvent
            {
                Items = randomItems.Select(item => _mapper.Map<Common.Core.Models.CatalogItem>(item)).ToArray()
            });
            await Task.CompletedTask;
        }
    }
}