using Bus.Abstractions;

namespace Bus.Events
{
    public class DocumentReceivedEvent : IntegrationEvent
    {
        public string DocumentSubject { get; set; }
        public byte[] DocumentBody { get; set; }
    }
}