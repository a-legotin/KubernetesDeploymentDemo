using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Events
{
    class DocumentReceivedEvent : IntegrationEvent
    {
        public string DocumentSubject { get; set; }
        public byte[] DocumentBody { get; set; }
    }
}
