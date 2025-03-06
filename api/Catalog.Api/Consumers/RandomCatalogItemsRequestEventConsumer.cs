using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Api.Database.Repository;
using Common.Bus.Events;
using Common.Core.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.Consumers;

internal class RandomCatalogItemsRequestEventConsumer : IConsumer<RandomCatalogItemsRequest>
{
    private readonly ICatalogItemsRepository _catalogItemsRepository;
    private readonly IBus _eventBus;
    private readonly ILogger<RandomCatalogItemsRequestEventConsumer> _logger;
    private readonly IMapper _mapper;

    public RandomCatalogItemsRequestEventConsumer(ILogger<RandomCatalogItemsRequestEventConsumer> logger,
        ICatalogItemsRepository catalogItemsRepository,
        IBus eventBus,
        IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _catalogItemsRepository = catalogItemsRepository;
        _eventBus = eventBus;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<RandomCatalogItemsRequest> context)
    {
        _logger.LogDebug("Got random catalog items request");
        var catalogItemDtos = _catalogItemsRepository.GetAll().ToArray();
        var randomItems = catalogItemDtos.OrderBy(c => Guid.NewGuid())
            .Take(new Random(DateTime.Now.Millisecond).Next(2, 10))
            .ToArray();
        await _eventBus.Publish(new RandomCatalogItemsPostedEvent
        {
            Items = randomItems.Select(item => _mapper.Map<CatalogItem>(item)).ToArray()
        });
        await Task.CompletedTask;
    }
}