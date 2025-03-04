using System.Linq;
using AutoMapper;
using Common.Core.Models;
using Orders.Api.Database.Models;

namespace Orders.Api.Infrastructure;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(
                dest => dest.Guid,
                opt => opt.MapFrom(src => src.Guid)
            )
            .ForMember(
                dest => dest.CustomerName,
                opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}")
            )
            .ForMember(
                dest => dest.CustomerGuid,
                opt => opt.MapFrom(src => src.Customer.Guid)
            )
            .ForMember(
                dest => dest.ItemGuids,
                opt => opt.MapFrom(src => src.Items.Select(item => item.Guid).ToArray())
            );

        CreateMap<OrderDto, Order>();

        CreateMap<OrderPreview, OrderDto>();
        CreateMap<OrderDto, OrderPreview>();
    }
}