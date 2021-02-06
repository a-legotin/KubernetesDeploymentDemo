using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Api.Database.Models;

namespace Orders.Api.Database.Repository
{
    public interface IOrdersRepository
    {
        IEnumerable<OrderDto> GetAll();
        Task InsertAsync(OrderDto order);
    }
}