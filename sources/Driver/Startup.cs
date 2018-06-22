using System;
using Driver.Messaging;
using GreenPipes;
using MassTransit.Extensions.Hosting;
using MassTransit.Extensions.Hosting.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Controller
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddMassTransit(busBuilder =>
            {
               
                busBuilder.UseRabbitMq("driver-connection", new Uri("rabbitmq://rabbitmq/"), hostBuilder =>
                {
                    hostBuilder.UseUsername("admin");
                    hostBuilder.UsePassword("admin");
                    
                    hostBuilder.AddReceiveEndpoint("docService" + Guid.NewGuid().ToString(), endpointBuilder =>
                    {
                        endpointBuilder.AddConfigurator(configureEndpoint =>
                        {
                            configureEndpoint.UseRetry(r => r.Immediate(3));
                        });

                        endpointBuilder.AddConsumer<StartGeneratorConsumer>(configureConsumer =>
                        {

                        });
                    });
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}