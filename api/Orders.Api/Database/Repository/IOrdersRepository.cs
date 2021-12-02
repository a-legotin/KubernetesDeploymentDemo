using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Api.Database.Models;

namespace Orders.Api.Database.Repository
{
    public interface IOrdersRepository
    {
        Task<List<OrderDto>> GetAll();
        Task InsertAsync(OrderDto order);
        Task<List<OrderDto>> GetLatest(int portion);
        Task<int> GetOrdersCount();
        Task<OrderDto> GetById(int orderId);
    }
}