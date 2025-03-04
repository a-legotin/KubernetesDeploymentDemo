using System;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;

namespace Common.Core.Logging;

public static class LoggingSetup
{
    public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =>
        (context, loggerConfiguration) =>
        {
            var env = context.HostingEnvironment;
            loggerConfiguration
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", env.ApplicationName)
                .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
                .Enrich.WithExceptionDetails()
                .WriteTo.Console();

            var elasticUrl = context.Configuration.GetValue<string>("Elastic:Uri");
            if (!string.IsNullOrEmpty(elasticUrl))
                loggerConfiguration.WriteTo.Elasticsearch(new[] { new Uri(elasticUrl) }, opts =>
                {
                    opts.DataStream = new DataStreamName("logs", "kdemo-logs", "kdemo");
                    opts.BootstrapMethod = BootstrapMethod.Failure;
                });

            loggerConfiguration.ReadFrom.Configuration(context.Configuration);
        };
}