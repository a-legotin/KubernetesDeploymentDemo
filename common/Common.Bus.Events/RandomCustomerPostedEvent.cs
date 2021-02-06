using Common.Bus.Abstractions;
using Common.Core.Models;

namespace Common.Bus.Events
{
    public class RandomCustomerPostedEvent : IntegrationMessage
    {
        public Customer Customer { get; set; }
    }
}