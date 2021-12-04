using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.Database.Repository
{
    internal class CatalogItemsRepository : ICatalogItemsRepository
    {
        private readonly CatalogDbContext _dbContext;
        private readonly ILogger<CatalogItemsRepository> _logger;

        public CatalogItemsRepository(CatalogDbContext dbContext, ILogger<CatalogItemsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IEnumerable<CatalogItemDto> GetAll()
        {
            _logger.LogTrace("Getting all catalog items with category");
            return _dbContext.Items.Include(dto => dto.Category);
        }

        public void Insert(CatalogItemDto catalogItem)
        {
            _logger.LogTrace("Inserting new catalog item");
            _dbContext.Items.Add(catalogItem);
            _dbContext.SaveChanges();
        }

        public async Task<int> GetCatalogItemsCount()
        {
            _logger.LogTrace("Getting all catalog items count");
            return await _dbContext.Items.CountAsync();
        }

        public async Task<CatalogItemDto> GetById(int itemId)
        {
            _logger.LogTrace($"Getting catalog item by id {itemId}");
            return await _dbContext.Items.FirstOrDefaultAsync(item => item.Id == itemId);
        }
        
        public async Task<CatalogItemDto> GetByGuid(Guid itemGuid)
        {
            _logger.LogTrace($"Getting catalog item by guid {itemGuid}");
            return await _dbContext.Items
                .Include(item => item.Category)
                .FirstOrDefaultAsync(item => item.Guid == itemGuid);
        }
    }
}