using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Customer.Api.Database.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Common.Core.Models.Customer> Get() => _customerRepository.GetAll()
            .Select(customer => _mapper.Map<Common.Core.Models.Customer>(customer));
    }
}