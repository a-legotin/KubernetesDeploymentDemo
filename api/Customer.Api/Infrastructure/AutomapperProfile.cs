using AutoMapper;
using Customer.Api.Database.Models;

namespace Customer.Api.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Common.Core.Models.Customer, CustomerDto>();
            CreateMap<CustomerDto, Common.Core.Models.Customer>();
        }
    }
}