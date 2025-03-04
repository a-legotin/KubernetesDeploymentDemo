using System.Threading;

namespace Service.Orders.Producer;

public interface IOrderProducerFactory
{
    IOrderProducer Construct(CancellationToken cancellationToken);
}