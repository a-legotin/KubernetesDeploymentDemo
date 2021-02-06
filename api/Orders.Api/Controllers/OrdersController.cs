using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Order> Get() => _ordersRepository.GetAll().Select(customer => _mapper.Map<Order>(customer));
    }
}