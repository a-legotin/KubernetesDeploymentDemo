using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bus.RabbitMQ;
using Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Posts.Wiki.Downloader;

namespace Posts.Wiki
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices(ConfigureServices)
                .ConfigureContainer<ContainerBuilder>(ConfigureContainer);

        private static void SetupConfiguration(HostBuilderContext hostBuilderContext,
            IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
        }

        private static void ConfigureServices(HostBuilderContext builder, IServiceCollection services)
        {
            services.AddHostedService<WikiPagesDownloadService>();
        }

        private static void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<RabbitIocModule>();
            containerBuilder.RegisterType<StandardHttpClient>().As<IHttpClient>();
            containerBuilder.RegisterType<WikiPageDownloader>().As<IWikiPageDownloader>();
        }
    }
}