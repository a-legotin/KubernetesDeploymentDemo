using System.Reflection;
using Customer.Api.Database.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        return services;
    }
}