using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using Common.Core.Models;
using CustomerService.Api.Database.Models;
using Microsoft.Extensions.Logging;

namespace CustomerService.Api.Database
{
    internal class SeedDataProvider : ISeedDataProvider<CustomerDto>
    {
        private readonly ILogger<SeedDataProvider> _logger;
        private readonly IMapper _mapper;

        private static readonly string dataFile = Path.Combine("DataBase", "SeedData", "customers.json");

        public SeedDataProvider(ILogger<SeedDataProvider> logger,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public CustomerDto[] GetSeedData()
        {
            var identifier = 1;
            if (File.Exists(dataFile))
                return (JsonSerializer.Deserialize<Customer[]>(File.ReadAllText(dataFile)) ?? Array.Empty<Customer>())
                    .Select(customer => _mapper.Map<CustomerDto>(customer))
                    .Select(customer =>
                    {
                        customer.Id = identifier++;
                        return customer;
                    })
                    .ToArray();
            _logger.LogWarning($"Datasource file not found {dataFile}");
            return Array.Empty<CustomerDto>();
        }
    }
    
    public interface ISeedDataProvider<T>
    {
        public T[] GetSeedData();
    }
}