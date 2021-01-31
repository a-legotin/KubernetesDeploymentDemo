using System.Collections.Generic;
using CustomerService.Api.Database.Models;
using Microsoft.Extensions.Logging;

namespace CustomerService.Api.Database.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;
        
        private readonly CustomerDbContext _dbContext;

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