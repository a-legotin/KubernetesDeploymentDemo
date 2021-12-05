using System;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    
                    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    var configuration = new ConfigurationBuilder()
                        .AddJsonFile($"appsettings.{environment}.json")
                        .Build();
                    
                    var logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .Enrich.WithClientAgent()
                        .WriteTo.Debug()
                        .WriteTo.Console()
                        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
                        {
                            AutoRegisterTemplate = true,
                            IndexFormat = $"kdemo-{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
                        })
                        .Enrich.WithProperty("Environment", environment)
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();
                    
                    logging.AddSerilog(logger, dispose: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSentry();
                    webBuilder.UseStartup<Startup>();
                });
    }
}