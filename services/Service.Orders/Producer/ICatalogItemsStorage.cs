using System.Collections.Concurrent;
using Common.Core.Models;

namespace Service.Orders.Producer;

internal interface ICatalogItemsStorage
{
    BlockingCollection<CatalogItem[]> Items { get; }
}