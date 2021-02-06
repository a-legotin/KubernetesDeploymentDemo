using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Customer.Api.Database.Repository;
using Microsoft.Extensions.Logging;

namespace Customer.Api.EventHandlers
{
    public class RandomCustomerRequestEventHandler : IIntegrationEventHandler<RandomCustomerRequest>
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<RandomCustomerRequestEventHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _postsRepository;

        public RandomCustomerRequestEventHandler(ILogger<RandomCustomerRequestEventHandler> logger,
            ICustomerRepository postsRepository,
            IEventBus eventBus,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _postsRepository = postsRepository;
            _eventBus = eventBus;
            _mapper = mapper;
        }

        public async Task Handle(RandomCustomerRequest request)
        {
            _logger.LogTrace("Got random customer request");
            var customers = _postsRepository.GetAll().ToArray();
            var randomCustomer = customers.OrderBy(c => Guid.NewGuid())
                .FirstOrDefault();
            _eventBus.Publish(new RandomCustomerPostedEvent
            {
                Customer = _mapper.Map<Common.Core.Models.Customer>(randomCustomer)
            });
            await Task.CompletedTask;
        }
    }
}