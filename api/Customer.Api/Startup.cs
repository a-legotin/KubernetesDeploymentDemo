using System.IO;
using System.Reflection;
using Autofac;
using AutoMapper;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Common.Bus.RabbitMQ;
using Customer.Api.Database;
using Customer.Api.Database.Repository;
using Customer.Api.EventHandlers;
using Customer.Api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customer.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var dbRetryCount = string.IsNullOrEmpty(Configuration["DbRetryCount"])
                ? 3
                : int.Parse(Configuration["DbRetryCount"]);

            services.AddDbContext<CustomerDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("PostgreSQLConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        b.EnableRetryOnFailure(dbRetryCount);
                    })
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        await context.Response.WriteAsync(
                            $"Exception: {exceptionHandlerPathFeature?.Error}<br><br>\r\n");

                        await context.Response.WriteAsync(
                            "<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512));
                    });
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            ConfigureEventBus(app);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>();
            containerBuilder.RegisterType<RandomCustomerRequestEventHandler>()
                .As<IIntegrationEventHandler<RandomCustomerRequest>>();
            containerBuilder.RegisterModule<RabbitIocModule>();
            containerBuilder
                .RegisterType<CustomerDbContext>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutomapperProfile()); });
            var mapper = mapperConfig.CreateMapper();
            containerBuilder.RegisterInstance(mapper);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<RandomCustomerRequest, IIntegrationEventHandler<RandomCustomerRequest>>();
        }
    }
}