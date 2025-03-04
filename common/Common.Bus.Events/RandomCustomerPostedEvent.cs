using Common.Core.Models;

namespace Common.Bus.Events;

public class RandomCustomerPostedEvent : BaseIntegrationMessage
{
    public Customer Customer { get; set; }
}