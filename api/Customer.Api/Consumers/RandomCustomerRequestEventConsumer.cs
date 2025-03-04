using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Bus.Events;
using Customer.Api.Database.Repository;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Customer.Api.Consumers;

public class RandomCustomerRequestEventConsumer : IConsumer<RandomCustomerRequest>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IBus _eventBus;
    private readonly ILogger<RandomCustomerRequestEventConsumer> _logger;
    private readonly IMapper _mapper;

    public RandomCustomerRequestEventConsumer(ILogger<RandomCustomerRequestEventConsumer> logger,
        ICustomerRepository customerRepository,
        IBus eventBus,
        IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _customerRepository = customerRepository;
        _eventBus = eventBus;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<RandomCustomerRequest> context)
    {
        _logger.LogDebug("Got random customer request {CorrelationId}", context.Message.CorrelationId);
        var randomCustomer = await _customerRepository.GetRandomAsync();
        await _eventBus.Publish(new RandomCustomerPostedEvent
        {
            Customer = _mapper.Map<Common.Core.Models.Customer>(randomCustomer)
        });
    }
}