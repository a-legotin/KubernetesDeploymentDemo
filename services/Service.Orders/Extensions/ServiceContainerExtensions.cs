using Autofac;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Common.Bus.RabbitMQ;
using Service.Orders.EventHandlers;
using Service.Orders.Producer;

namespace Service.Orders.Extensions
{
    public static class ServiceContainerExtensions
    {
        public static void ConfigureBuilder(this ContainerBuilder builder)
        {
            builder.RegisterModule<RabbitIocModule>();
            builder.RegisterType<RandomCatalogItemsPostedEventEventHandler>()
                .As<IIntegrationEventHandler<RandomCatalogItemsPostedEvent>>();
            builder.RegisterType<RandomCustomerPostedEventHandler>()
                .As<IIntegrationEventHandler<RandomCustomerPostedEvent>>();

            builder.RegisterType<OrderProducerFactory>()
                .As<IOrderProducerFactory>()
                .SingleInstance();

            builder.RegisterType<CatalogItemsStorage>()
                .As<ICatalogItemsStorage>()
                .SingleInstance();

            builder.RegisterType<CustomersStorage>()
                .As<ICustomersStorage>()
                .SingleInstance();
        }
    }
}