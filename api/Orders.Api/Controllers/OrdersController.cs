using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Orders.Api.Database.Repository;

namespace Orders.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOrdersRepository _ordersRepository;

    public OrdersController(IOrdersRepository ordersRepository, IMapper mapper)
    {
        _ordersRepository = ordersRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<OrderPreview[]> Get()
    {
        return (await _ordersRepository.GetAll())
            .Select(customer => _mapper.Map<OrderPreview>(customer))
            .ToArray();
    }

    [HttpGet("{orderId:int}")]
    public async Task<OrderPreview> GetById(int orderId)
    {
        return _mapper.Map<OrderPreview>(await _ordersRepository.GetById(orderId));
    }

    [HttpGet("latest")]
    public async Task<OrderPreview[]> GetLatest([FromQuery] int portion)
    {
        if (portion < 1) portion = 1;
        return (await _ordersRepository.GetLatest(portion))
            .Select(customer => _mapper.Map<OrderPreview>(customer))
            .ToArray();
    }

    [HttpGet("count")]
    public async Task<int> GetOrdersCount()
    {
        return await _ordersRepository.GetOrdersCount();
    }
}