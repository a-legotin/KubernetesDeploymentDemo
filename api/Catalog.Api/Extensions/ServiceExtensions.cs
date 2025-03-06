using System.Reflection;
using Catalog.Api.Database.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Api.Extensions;

internal static class ServiceExtensions
{
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ICatalogItemsRepository, CatalogItemsRepository>();
        services.AddScoped<ICatalogCategoryRepository, CatalogCategoryRepository>();

        return services;
    }
}