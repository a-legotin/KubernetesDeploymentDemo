﻿using System.Linq;
using AutoMapper;
using Orders.Api.Database.Models;

namespace Orders.Api.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Common.Core.Models.Order, OrderDto>()
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

            CreateMap<OrderDto, Common.Core.Models.Order>();

            CreateMap<Common.Core.Models.OrderPreview, OrderDto>();
            CreateMap<OrderDto, Common.Core.Models.OrderPreview>();
        }
    }
}