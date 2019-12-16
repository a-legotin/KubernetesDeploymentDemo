using Bus.Abstractions;

namespace Bus.Events
{
    public class StartReceivingEvent : IntegrationEvent
    {
        public int DocumentsAmount { get; set; }
    }
}