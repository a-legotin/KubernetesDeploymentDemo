using System.Threading;

namespace Service.Orders.Producer
{
    public class OrderProducerFactory : IOrderProducerFactory
    {
        private readonly ICatalogItemsStorage _catalogItems;
        private readonly ICustomersStorage _customers;

        public OrderProducerFactory(ICustomersStorage customers, ICatalogItemsStorage catalogItems)
        {
            _customers = customers;
            _catalogItems = catalogItems;
        }

        public IOrderProducer Construct(CancellationToken cancellationToken) =>
            new OrderProducer(cancellationToken, _customers, _catalogItems);
    }
}