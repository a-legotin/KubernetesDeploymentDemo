using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Database.Models;

namespace Catalog.Api.Database.Repository
{
    public interface ICatalogItemsRepository
    {
        IEnumerable<CatalogItemDto> GetAll();
        void Insert(CatalogItemDto catalogItem);
        Task<int> GetCatalogItemsCount();
    }
}