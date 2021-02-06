using Common.Bus.Abstractions;

namespace Common.Bus.Events
{
    public class RandomCatalogItemsRequest : IntegrationMessage
    {
        public int Portion { get; set; }
    }
}