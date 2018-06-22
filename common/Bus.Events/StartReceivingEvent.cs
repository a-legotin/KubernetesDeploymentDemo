using System;
using System.Collections.Generic;
using System.Text;

namespace Bus.Events
{
    public class StartReceivingEvent : IntegrationEvent
    {
        public int DocumentsAmount { get; set; }
    }
}
