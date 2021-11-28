using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Orders.Api.Database.Repository;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<Order[]> Get() => (await _ordersRepository.GetAll())
            .Select(customer => _mapper.Map<Order>(customer))
            .ToArray();
        
        [HttpGet("latest")]
        public async Task<Order[]> GetLatest([FromQuery] int portion)
        {
            if (portion < 1)
            {
                portion = 1;
            }
            return (await _ordersRepository.GetLatest(portion))
                .Select(customer => _mapper.Map<Order>(customer))
                .ToArray();
        }
    }
}