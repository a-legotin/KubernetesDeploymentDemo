using Microsoft.Extensions.DependencyInjection;

namespace Service.Orders.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static void ConfigureWorker(this IServiceCollection services)
        {
            services.AddHostedService<OrdersWorker>();
        }
    }
}