using System;
using System.Threading;
using Common.Core.Models;

namespace Service.Orders.Producer;

internal class OrderProducer : IOrderProducer
{
    private readonly int _blockingTimeOutMilliseconds = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;
    private readonly CancellationToken _cancellationToken;
    private readonly ICatalogItemsStorage _catalogItems;
    private readonly ICustomersStorage _customers;

    public OrderProducer(CancellationToken cancellationToken, ICustomersStorage customers,
        ICatalogItemsStorage catalogItems)
    {
        _cancellationToken = cancellationToken;
        _customers = customers;
        _catalogItems = catalogItems;
    }

    public Order GetNextOrder()
    {
        if (!_customers.Customers.TryTake(out var customer, _blockingTimeOutMilliseconds,
                _cancellationToken))
            return null;
        if (!_catalogItems.Items.TryTake(out var catalogItems, _blockingTimeOutMilliseconds, _cancellationToken))
            return null;
        return new Order
        {
            Customer = customer,
            Guid = Guid.NewGuid(),
            Items = catalogItems
        };
    }
}