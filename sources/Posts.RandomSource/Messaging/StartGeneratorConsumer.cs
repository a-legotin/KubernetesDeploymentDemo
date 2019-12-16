using System;
using System.Threading.Tasks;
using Bus.Events;
using MassTransit;

namespace Posts.RandomSource.Messaging
{
    public class StartGeneratorConsumer : IConsumer<StartReceivingEvent>
    {
        public StartGeneratorConsumer()
        {
        }

        public async Task Consume(ConsumeContext<StartReceivingEvent> context)
        {
            await Task.Run(() => { Console.WriteLine($"Event received {context.Message.DocumentsAmount}"); });
        }
    }
}