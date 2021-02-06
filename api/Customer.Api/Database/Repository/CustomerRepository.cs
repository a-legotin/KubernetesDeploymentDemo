using System.Collections.Generic;
using Customer.Api.Database.Models;
using Microsoft.Extensions.Logging;

namespace Customer.Api.Database.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(CustomerDbContext dbContext, ILogger<CustomerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            _logger.LogTrace("Getting all customers");
            return _dbContext.Customers;
        }
    }
}