using System;
using System.Threading;
using System.Threading.Tasks;
using Bus.Abstractions;
using Bus.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Posts.Wiki.Downloader;

namespace Posts.Wiki
{
    internal class WikiPagesDownloadService : BackgroundService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<WikiPagesDownloadService> _logger;
        private readonly IWikiPageDownloader _wikiPageDownloader;

        public WikiPagesDownloadService(ILogger<WikiPagesDownloadService> logger,
            IEventBus eventBus,
            IWikiPageDownloader wikiPageDownloader)
        {
            _logger = logger;
            _eventBus = eventBus;
            _wikiPageDownloader = wikiPageDownloader;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Downloading random wiki page", DateTimeOffset.Now);
                try
                {
                    var page = await _wikiPageDownloader.GetRandomWikiPage();
                    _eventBus.Publish(new WebPostDownloadedEvent(page));
                }
                catch (Exception e)
                {
                    _logger.LogError($"Unable to download wiki page: {e}", DateTimeOffset.Now);
                }
            }
        }
    }
}