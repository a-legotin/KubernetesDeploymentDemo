using System.Linq;
using Catalog.Api.Database.Models;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.Database.Repository;

internal class CatalogCategoryRepository : ICatalogCategoryRepository
{
    private readonly CatalogDbContext _dbContext;
    private readonly ILogger<CatalogCategoryRepository> _logger;

    public CatalogCategoryRepository(CatalogDbContext dbContext, ILogger<CatalogCategoryRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public CatalogCategoryDto GetByDescription(string description)
    {
        return _dbContext.Categories.FirstOrDefault(dto => dto.Description == description);
    }


    public void Insert(CatalogCategoryDto category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }
}