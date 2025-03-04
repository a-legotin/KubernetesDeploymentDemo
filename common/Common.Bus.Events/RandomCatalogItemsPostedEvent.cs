using Common.Core.Models;

namespace Common.Bus.Events;

public class RandomCatalogItemsPostedEvent : BaseIntegrationMessage
{
    public CatalogItem[] Items { get; set; }
}