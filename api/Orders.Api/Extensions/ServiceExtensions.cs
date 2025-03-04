using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Orders.Api.Consumers;
using Orders.Api.Database.Repository;

namespace Orders.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IOrdersRepository, OrderRepository>();
        services.AddScoped<OrderPostedEventConsumer>();

        return services;
    }
}