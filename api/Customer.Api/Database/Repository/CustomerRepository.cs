﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Api.Database.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> GetCustomerCount()
        {
            _logger.LogTrace("Getting total customers count");
            return await _dbContext.Customers.CountAsync();
        }

        public async Task<CustomerDto> GetById(int customerId)
        {
            _logger.LogTrace("Getting customer by id {CustomerId}", customerId);
            return await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == customerId);
        }

        public async Task<CustomerDto> GetByGuid(Guid customerGuid)
        {
            _logger.LogTrace("Getting customer by guid {CustomerGuid}", customerGuid);
            return await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.Guid == customerGuid);
        }
    }
}