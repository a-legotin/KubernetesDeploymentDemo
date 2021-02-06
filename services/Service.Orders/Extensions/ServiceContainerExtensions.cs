using Autofac;
using Common.Bus.RabbitMQ;

namespace Service.Orders.Extensions
{
    public static class ServiceContainerExtensions
    {
        public static void ConfigureBuilder(this ContainerBuilder builder)
        {
            builder.RegisterModule<RabbitIocModule>();
        }
    }
}