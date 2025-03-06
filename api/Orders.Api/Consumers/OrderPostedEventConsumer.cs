using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Bus.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Orders.Api.Database.Models;
using Orders.Api.Database.Repository;

namespace Orders.Api.Consumers;

internal class OrderPostedEventConsumer : IConsumer<OrderPostedEvent>
{
    private readonly ILogger<OrderPostedEventConsumer> _logger;
    private readonly IMapper _mapper;
    private readonly IOrdersRepository _ordersRepository;

    public OrderPostedEventConsumer(ILogger<OrderPostedEventConsumer> logger,
        IOrdersRepository ordersRepository,
        IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _ordersRepository = ordersRepository;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<OrderPostedEvent> context)
    {
        _logger.LogDebug("Got an event {CorrelationId} created at {CreatedAt}", context.Message.CorrelationId,
            context.Message.CreatedAt);
        var addedOrder = await _ordersRepository.InsertAsync(_mapper.Map<OrderDto>(context.Message.Order));
        _logger.LogDebug("Order {OrderId} created at {CreatedAt}", addedOrder.Id, DateTime.Now);
    }
}