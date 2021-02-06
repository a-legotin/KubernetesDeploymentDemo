using Common.Bus.Abstractions;
using Common.Core.Models;

namespace Common.Bus.Events
{
    public class OrderPostedEvent : IntegrationEvent
    {
        public Order Order { get; set; }
    }
}