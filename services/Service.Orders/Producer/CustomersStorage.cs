using System.Collections.Concurrent;
using Common.Core.Models;

namespace Service.Orders.Producer;

internal class CustomersStorage : ICustomersStorage
{
    public CustomersStorage()
    {
        Customers = new BlockingCollection<Customer>();
    }

    public BlockingCollection<Customer> Customers { get; }
}