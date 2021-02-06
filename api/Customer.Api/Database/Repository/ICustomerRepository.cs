using System.Collections.Generic;
using Customer.Api.Database.Models;

namespace Customer.Api.Database.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDto> GetAll();
    }
}