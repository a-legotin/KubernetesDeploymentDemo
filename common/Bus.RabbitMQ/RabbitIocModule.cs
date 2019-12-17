using Autofac;
using Bus.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Bus.RabbitMQ
{
    public class RabbitIocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(componentContext =>
                {
                    var config = componentContext.Resolve<IConfiguration>();
                    var factory = new ConnectionFactory
                    {
                        HostName = config["EventBusConnection"],
                        Port = int.Parse(config["EventBusPort"]),
                        DispatchConsumersAsync = true
                    };
                    if (!string.IsNullOrEmpty(config["EventBusUserName"]))
                        factory.UserName = config["EventBusUserName"];

                    if (!string.IsNullOrEmpty(config["EventBusPassword"]))
                        factory.Password = config["EventBusPassword"];

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(config["EventBusRetryCount"]))
                        retryCount = int.Parse(config["EventBusRetryCount"]);

                    var logger = componentContext.Resolve<ILogger<IRabbitMQPersistentConnection>>();
                    return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
                    ;
                })
                .As<IRabbitMQPersistentConnection>()
                .SingleInstance();

            var eventBusSubscriptionsManager = new InMemoryEventBusSubscriptionsManager();

            builder.Register(manager => eventBusSubscriptionsManager)
                .As<IEventBusSubscriptionsManager>()
                .SingleInstance();

            builder.Register(c
                    =>
                {
                    var rabbitConnection = c.Resolve<IRabbitMQPersistentConnection>();
                    var logger = c.Resolve<ILogger<IEventBus>>();
                    var config = c.Resolve<IConfiguration>();
                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(config["EventBusRetryCount"]))
                        retryCount = int.Parse(config["EventBusRetryCount"]);

                    return new EventBusRabbitMQ(rabbitConnection, logger, c.Resolve<ILifetimeScope>(),
                        eventBusSubscriptionsManager, config["SubscriptionClientName"], retryCount);
                })
                .As<IEventBus>()
                .SingleInstance();
        }
    }
}