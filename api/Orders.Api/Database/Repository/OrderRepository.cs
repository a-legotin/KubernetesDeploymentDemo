using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Orders.Api.Database.Models;

namespace Orders.Api.Database.Repository
{
    internal class OrderRepository : IOrdersRepository
    {
        private readonly OrdersDbContext _dbContext;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(OrdersDbContext dbContext, ILogger<OrderRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<OrderDto>> GetAll()
        {
            _logger.LogTrace("Getting all orders");
            return _dbContext.Orders
                .ToListAsync();
        }

        public async Task InsertAsync(OrderDto order)
        {
            _logger.LogTrace($"Inserting order {order.Guid}");
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<OrderDto>> GetLatest(int portion)
        {
            _logger.LogTrace($"Getting {portion} latest orders");
            return _dbContext.Orders
                .OrderByDescending(dto => dto.Id)
                .Take(portion)
                .ToListAsync();
        }
    }
}