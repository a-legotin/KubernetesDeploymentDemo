using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Orders.Api.Database.Models;

namespace Orders.Api.Database.Repository;

internal class OrderRepository : IOrdersRepository
{
    private readonly OrdersDbContext _dbContext;
    private readonly ILogger<OrderRepository> _logger;

    public OrderRepository(OrdersDbContext dbContext, ILogger<OrderRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<List<OrderDto>> GetAll()
    {
        _logger.LogDebug("Getting all orders");
        return await _dbContext.Orders
            .ToListAsync();
    }

    public async Task<OrderDto> InsertAsync(OrderDto order)
    {
        _logger.LogDebug("Inserting order {OrderGuid}", order.Guid);
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public async Task<List<OrderDto>> GetLatest(int portion)
    {
        _logger.LogDebug("Getting {Portion} latest orders", portion);
        return await _dbContext.Orders
            .OrderByDescending(dto => dto.Id)
            .Take(portion)
            .ToListAsync();
    }

    public async Task<int> GetOrdersCount()
    {
        _logger.LogDebug("Getting orders count");
        return await _dbContext.Orders.CountAsync();
    }

    public async Task<OrderDto> GetById(int orderId)
    {
        _logger.LogDebug("Getting order by id {OrderId}", orderId);
        return await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == orderId);
    }
}