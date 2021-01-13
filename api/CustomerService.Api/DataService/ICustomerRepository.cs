using Common.Core.Models;

namespace CustomerService.Api.DataService
{
    public interface ICustomerRepository
    {
        Customer[] GetAll();
    }
}