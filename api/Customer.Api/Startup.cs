using System.Reflection;
using AutoMapper;
using CustomerService.Api.Database;
using CustomerService.Api.Database.Models;
using CustomerService.Api.Database.Repository;
using CustomerService.Api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CustomerService.Api
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

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<DatabaseOptions>(Configuration.GetSection(DatabaseOptions.Key));
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutomapperProfile()); });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddSingleton<ISeedDataProvider<CustomerDto>, SeedDataProvider>();

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CustomerDbContext>();
                context?.Database.CanConnect();
            }
        }
    }
}