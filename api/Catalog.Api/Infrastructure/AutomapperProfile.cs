using AutoMapper;
using Catalog.Api.Database.Models;
using Common.Core.Models;

namespace Catalog.Api.Infrastructure
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CatalogCategory, CatalogCategoryDto>();
            CreateMap<CatalogCategoryDto, CatalogCategory>();
            CreateMap<CatalogItem, CatalogItemDto>();
            CreateMap<CatalogItemDto, CatalogItem>();
        }
    }
}