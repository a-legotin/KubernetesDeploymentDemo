using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Orders.Api.Database.Repository;

namespace Orders.Api.Controllers
{
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
        public async Task<OrderPreview[]> Get() => (await _ordersRepository.GetAll())
            .Select(customer => _mapper.Map<OrderPreview>(customer))
            .ToArray();
        
        [HttpGet("latest")]
        public async Task<OrderPreview[]> GetLatest([FromQuery] int portion)
        {
            if (portion < 1)
            {
                portion = 1;
            }
            return (await _ordersRepository.GetLatest(portion))
                .Select(customer => _mapper.Map<OrderPreview>(customer))
                .ToArray();
        }
        
        [HttpGet("count")]
        public async Task<int> GetOrdersCount() => (await _ordersRepository.GetOrdersCount());
    }
}