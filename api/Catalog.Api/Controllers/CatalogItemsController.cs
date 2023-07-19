using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Api.Database.Repository;
using Common.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/catalog/items")]
    public class CatalogItemsController : ControllerBase
    {
        private readonly ICatalogItemsRepository _catalogItemsRepository;
        private readonly IMapper _mapper;

        public CatalogItemsController(ICatalogItemsRepository catalogItemsRepository, IMapper mapper)
        {
            _catalogItemsRepository = catalogItemsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CatalogItem> Get() =>
            _catalogItemsRepository.GetAll().Select(item => _mapper.Map<CatalogItem>(item));

        [HttpGet("{itemId:int}")]
        public async Task<CatalogItem> GetById(int itemId) => _mapper.Map<CatalogItem>(await _catalogItemsRepository.GetById(itemId));

        [HttpGet("{itemGuid:guid}")]
        public async Task<CatalogItem> GetById(Guid itemGuid) => _mapper.Map<CatalogItem>(await _catalogItemsRepository.GetByGuid(itemGuid));

        [HttpGet("count")]
        public async Task<int> GetCatalogItemsCount() => (await _catalogItemsRepository.GetCatalogItemsCount());
    }
}