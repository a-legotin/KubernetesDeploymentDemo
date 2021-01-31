using AutoMapper;
using Common.Core.Models;
using CustomerService.Api.Database.Models;

namespace CustomerService.Api.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}