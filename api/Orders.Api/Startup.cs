using System.IO;
using System.Reflection;
using Autofac;
using AutoMapper;
using Common.Bus.Abstractions;
using Common.Bus.Events;
using Common.Bus.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orders.Api.Database;
using Orders.Api.Database.Repository;
using Orders.Api.EventHandlers;
using Orders.Api.Infrastructure;

namespace Orders.Api
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

        public ILifetimeScope AutofacContainer { get; private set; }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var dbRetryCount = string.IsNullOrEmpty(Configuration["DbRetryCount"])
                ? 3
                : int.Parse(Configuration["DbRetryCount"]);

            services.AddDbContext<OrdersDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("PostgreSQLConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        b.EnableRetryOnFailure(dbRetryCount);
                    })
            );

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
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

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            
            app.UseRouting();
            app.UseSentryTracing();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            ConfigureEventBus(app);
            ApplyMigrations(app);
        }

        private void ApplyMigrations(IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();
            db.Database.Migrate();
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<OrderRepository>().As<IOrdersRepository>();
            containerBuilder.RegisterType<OrderPostedEventHandler>()
                .As<IIntegrationEventHandler<OrderPostedEvent>>();
            containerBuilder.RegisterModule<RabbitIocModule>();
            containerBuilder
                .RegisterType<OrdersDbContext>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutomapperProfile()); });
            var mapper = mapperConfig.CreateMapper();
            containerBuilder.RegisterInstance(mapper);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<OrderPostedEvent, IIntegrationEventHandler<OrderPostedEvent>>();
        }
    }
}