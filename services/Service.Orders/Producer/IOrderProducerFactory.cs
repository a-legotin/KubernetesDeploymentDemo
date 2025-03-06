using System.Threading;

namespace Service.Orders.Producer;

internal interface IOrderProducerFactory
{
    IOrderProducer Construct(CancellationToken cancellationToken);
}