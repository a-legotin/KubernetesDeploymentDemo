using Common.Core.Models;

namespace Service.Orders.Producer;

public interface IOrderProducer
{
    Order GetNextOrder();
}