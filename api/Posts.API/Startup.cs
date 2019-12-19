using Autofac;
using Bus.Abstractions;
using Bus.Events;
using Bus.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Posts.API.BusEventHandlers;
using Posts.API.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Posts.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        public ILifetimeScope AutofacContainer { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PostDbContextDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("PostgreSQLConnection"),
                    b => b.MigrationsAssembly("Posts.API")
                )
            );
            services.AddControllers();
            services.AddOptions();
        }
        
        
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<PostsRepository>().As<IPostsRepository>();
            containerBuilder.RegisterType<WebPostDownloadedEventHandler>().As<IIntegrationEventHandler<WebPostDownloadedEvent>>();
            containerBuilder.RegisterModule<RabbitIocModule>();
            containerBuilder
                .RegisterType<PostDbContextDbContext>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            ConfigureEventBus(app);
        }
        
        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<WebPostDownloadedEvent, IIntegrationEventHandler<WebPostDownloadedEvent>>();
        }
    }
}