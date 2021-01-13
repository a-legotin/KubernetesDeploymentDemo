using System.Collections.Generic;
using Common.Core.Models;
using CustomerService.Api.DataService;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository) => _customerRepository = customerRepository;

        [HttpGet]
        public IEnumerable<Customer> Get() => _customerRepository.GetAll();
    }
}