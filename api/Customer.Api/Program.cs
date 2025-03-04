using Common.Bus.Abstractions;
using Common.Core.Logging;
using Customer.Api.Consumers;
using Customer.Api.Database;
using Customer.Api.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Customer.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                policy => { policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
        });

        builder.Host.UseSerilog(LoggingSetup.ConfigureLogger);
        builder.Services.AddControllers();


        builder.Services.AddMassTransit(config =>
        {
            config.AddConsumer<RandomCustomerRequestEventConsumer>();
            config.UsingRabbitMq((ct, cfg) =>
            {
                cfg.Host(builder.Configuration["EventBus:HostAddress"]);

                cfg.ReceiveEndpoint(EventBusConstants.RandomCustomerRequested,
                    c => { c.ConfigureConsumer<RandomCustomerRequestEventConsumer>(ct); });
            });
        });

        var dbRetryCount = string.IsNullOrEmpty(builder.Configuration["DbRetryCount"])
            ? 3
            : int.Parse(builder.Configuration["DbRetryCount"]);

        builder.Services.AddDbContext<CustomerDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(dbRetryCount));
        });

        builder.Services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });

        builder.Services.ConfigureAppServices();

        var app = builder.Build();

        if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

        ApplyMigrations(app);

        app.UseCors("CorsPolicy");
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    private static void ApplyMigrations(IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
        db.Database.Migrate();
    }
}