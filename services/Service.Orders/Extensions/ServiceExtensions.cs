using Microsoft.Extensions.DependencyInjection;
using Service.Orders.Consumers;
using Service.Orders.Producer;

namespace Service.Orders.Extensions;

internal static class ServiceExtensions
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<RandomCatalogItemsPostedEventConsumer>();
        services.AddScoped<RandomCustomerPostedEventConsumer>();
        services.AddScoped<IOrderProducerFactory, OrderProducerFactory>();
        services.AddSingleton<IOrderProducerFactory, OrderProducerFactory>();
        services.AddSingleton<ICatalogItemsStorage, CatalogItemsStorage>();
        services.AddSingleton<ICustomersStorage, CustomersStorage>();
    }

    public static void ConfigureWorker(this IServiceCollection services)
    {
        services.AddHostedService<OrderGenerator>();
    }
}