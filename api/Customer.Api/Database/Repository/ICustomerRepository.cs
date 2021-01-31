using System.Collections.Generic;
using CustomerService.Api.Database.Models;

namespace CustomerService.Api.Database.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDto> GetAll();
    }
}