using System.Collections.Concurrent;
using Common.Core.Models;

namespace Service.Orders.Producer;

public interface ICatalogItemsStorage
{
    BlockingCollection<CatalogItem[]> Items { get; }
}