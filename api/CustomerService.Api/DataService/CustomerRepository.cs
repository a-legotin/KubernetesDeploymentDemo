using System;
using System.IO;
using System.Text.Json;
using Common.Core.Models;
using Microsoft.Extensions.Logging;

namespace CustomerService.Api.DataService
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;

        private static readonly string dataFile = Path.Combine("Data", "customers.json");

        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _logger = logger;
        }

        public Customer[] GetAll()
        {
            if (File.Exists(dataFile))
                return JsonSerializer.Deserialize<Customer[]>(File.ReadAllText(dataFile));
            _logger.LogWarning($"Datasource file not found {dataFile}");
            return Array.Empty<Customer>();
        }
    }
}