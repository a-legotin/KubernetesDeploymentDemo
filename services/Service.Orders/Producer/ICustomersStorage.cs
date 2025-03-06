using System.Collections.Concurrent;
using Common.Core.Models;

namespace Service.Orders.Producer;

internal interface ICustomersStorage
{
    BlockingCollection<Customer> Customers { get; }
}