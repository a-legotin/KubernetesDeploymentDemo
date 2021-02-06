using System;
using System.Threading.Tasks;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Microsoft.Extensions.Logging;
using Service.Orders.Producer;

namespace Service.Orders.EventHandlers
{
    public class RandomCustomerPostedEventHandler : IIntegrationEventHandler<RandomCustomerPostedEvent>
    {
        private readonly ICustomersStorage _customers;
        private readonly ILogger<RandomCustomerPostedEventHandler> _logger;

        public RandomCustomerPostedEventHandler(ILogger<RandomCustomerPostedEventHandler> logger,
            ICustomersStorage customers)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customers = customers;
        }

        public async Task Handle(RandomCustomerPostedEvent request)
        {
            _logger.LogTrace($"Got an event {request.Id} created at {request.CreationDate}");
            _customers.Customers.Add(request.Customer);
            await Task.CompletedTask;
        }
    }
}