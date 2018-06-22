using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bus.Events;
using MassTransit;

namespace Driver.Messaging
{
    public class StartGeneratorConsumer : IConsumer<StartReceivingEvent>
    {
        public StartGeneratorConsumer()
        {
        }

        public async Task Consume(ConsumeContext<StartReceivingEvent> context)
        {
            await Task.Run(() => { Console.WriteLine($"Event received {context.Message.DocumentsAmount}");});
        }
    }
}
