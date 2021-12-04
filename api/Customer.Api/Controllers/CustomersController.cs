using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        [HttpGet("{customerId:int}")]
        public async Task<Common.Core.Models.Customer> GetById(int customerId) => _mapper.Map<Common.Core.Models.Customer>(await _customerRepository.GetById(customerId));
        
        [HttpGet("{customerGuid:guid}")]
        public async Task<Common.Core.Models.Customer> GetById(Guid customerGuid) => _mapper.Map<Common.Core.Models.Customer>(await _customerRepository.GetByGuid(customerGuid));
        
        [HttpGet("count")]
        public async Task<int> GetCustomerCount() => (await _customerRepository.GetCustomerCount());
    }
}