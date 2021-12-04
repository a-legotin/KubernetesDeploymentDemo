using AutoMapper;
using Customer.Api.Database.Models;

namespace Customer.Api.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Common.Core.Models.Customer, CustomerDto>()
                .ForMember(
                    dest => dest.UpdatedTime,
                    opt => opt.MapFrom(src => src.UpdatedAt)
                );
            CreateMap<CustomerDto, Common.Core.Models.Customer>()
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => src.UpdatedTime)
                );;
        }
    }
}