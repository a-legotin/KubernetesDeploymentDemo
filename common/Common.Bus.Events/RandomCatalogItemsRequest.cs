namespace Common.Bus.Events;

public class RandomCatalogItemsRequest : BaseIntegrationMessage
{
    public int Portion { get; set; }
}