using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Common.Core.Models;
using CustomerService.Api.Database.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<Customer> Get() => _customerRepository.GetAll().Select(customer => _mapper.Map<Customer>(customer));
    }
}