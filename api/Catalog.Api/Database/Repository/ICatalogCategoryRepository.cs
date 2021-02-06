using Catalog.Api.Database.Models;

namespace Catalog.Api.Database.Repository
{
    public interface ICatalogCategoryRepository
    {
        CatalogCategoryDto GetByDescription(string description);
        void Insert(CatalogCategoryDto category);
    }
}