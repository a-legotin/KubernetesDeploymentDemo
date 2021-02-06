using System.Collections.Concurrent;
using Common.Core.Models;

namespace Service.Orders.Producer
{
    public interface ICustomersStorage
    {
        BlockingCollection<Customer> Customers { get; }
    }
}