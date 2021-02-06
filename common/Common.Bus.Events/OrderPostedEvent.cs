using Common.Bus.Abstractions;
using Common.Core.Models;

namespace Common.Bus.Events
{
    public class OrderPostedEvent : IntegrationMessage
    {
        public Order Order { get; set; }
    }
}