using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Api.Database.Models;

namespace Customer.Api.Database.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDto> GetAll();
        Task<int> GetCustomerCount();
    }
}