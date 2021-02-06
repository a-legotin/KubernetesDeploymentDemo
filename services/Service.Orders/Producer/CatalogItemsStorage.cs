using System.Collections.Concurrent;
using Common.Core.Models;

namespace Service.Orders.Producer
{
    public class CatalogItemsStorage : ICatalogItemsStorage
    {
        public CatalogItemsStorage() => Items = new BlockingCollection<CatalogItem[]>();

        public BlockingCollection<CatalogItem[]> Items { get; }
    }
}