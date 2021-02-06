using System.Collections.Generic;
using Catalog.Api.Database.Models;

namespace Catalog.Api.Database.Repository
{
    public interface ICatalogItemsRepository
    {
        IEnumerable<CatalogItemDto> GetAll();
        void Insert(CatalogItemDto catalogItem);
    }
}