using Common.Core.Models;

namespace Service.Orders.Producer;

internal interface IOrderProducer
{
    Order GetNextOrder();
}