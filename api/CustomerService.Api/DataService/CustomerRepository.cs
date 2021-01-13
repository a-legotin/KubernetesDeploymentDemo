using System.IO;
using System.Text.Json;
using Common.Core.Models;

namespace CustomerService.Api.DataService
{
    internal class CustomerRepository : ICustomerRepository
    {
        private static readonly string dataFile = @"Data\customers.json";

        public Customer[] GetAll() =>
            !File.Exists(dataFile)
                ? System.Array.Empty<Customer>()
                : JsonSerializer.Deserialize<Customer[]>(File.ReadAllText(dataFile));
    }
}