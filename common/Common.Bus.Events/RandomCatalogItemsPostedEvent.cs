using Common.Bus.Abstractions;
using Common.Core.Models;

namespace Common.Bus.Events
{
    public class RandomCatalogItemsPostedEvent : IntegrationMessage
    {
        public CatalogItem[] Items { get; set; }
    }
}