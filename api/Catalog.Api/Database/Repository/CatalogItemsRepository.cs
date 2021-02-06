using System.Collections.Generic;
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
            _dbContext.Items.Add(catalogItem);
            _dbContext.SaveChanges();
        }
    }
}