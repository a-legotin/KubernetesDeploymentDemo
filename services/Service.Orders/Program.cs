using Common.Bus.Abstractions;
using Common.Core.Logging;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Service.Orders.Consumers;
using Service.Orders.Extensions;

namespace Service.Orders;

public class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                var settingsFileName = $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json";

                configBuilder
                    .AddJsonFile(settingsFileName, false, true)
                    .AddEnvironmentVariables()
                    .Build();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddMassTransit(config =>
                {
                    config.AddConsumer<RandomCatalogItemsPostedEventConsumer>();
                    config.AddConsumer<RandomCustomerPostedEventConsumer>();

                    config.UsingRabbitMq((ct, cfg) =>
                    {
                        cfg.Host(context.Configuration["EventBus:HostAddress"]);

                        cfg.ReceiveEndpoint(EventBusConstants.RandomCatalogItemsPosted,
                            c => { c.ConfigureConsumer<RandomCatalogItemsPostedEventConsumer>(ct); });
                        cfg.ReceiveEndpoint(EventBusConstants.RandomCustomerPosted,
                            c => { c.ConfigureConsumer<RandomCustomerPostedEventConsumer>(ct); });
                    });
                });

                services.ConfigureApplicationServices();
                services.ConfigureWorker();
            })
            .UseSerilog(LoggingSetup.ConfigureLogger)
            .Build();

        host.Run();
    }
}