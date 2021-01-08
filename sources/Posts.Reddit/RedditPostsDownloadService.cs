using System;
using System.Threading;
using System.Threading.Tasks;
using Bus.Abstractions;
using Bus.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Posts.Reddit.Downloader;

namespace Posts.Reddit
{
    internal class RedditPostsDownloadService : BackgroundService
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<RedditPostsDownloadService> _logger;
        private readonly IRedditPostsDownloader _redditPostsDownloader;

        public RedditPostsDownloadService(ILogger<RedditPostsDownloadService> logger,
            IEventBus eventBus,
            IRedditPostsDownloader redditPostsDownloader)
        {
            _logger = logger;
            _eventBus = eventBus;
            _redditPostsDownloader = redditPostsDownloader;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
                try
                {
                    _logger.LogDebug("Downloading random reddit post", DateTimeOffset.Now);
                    var post = await _redditPostsDownloader.GetRandomPostAsync();
                    _eventBus.Publish(new WebPostDownloadedEvent(post));
                    _logger.LogDebug($"Reddit post {post.Subject} published");
                }
                catch (Exception e)
                {
                    _logger.LogError($"Unable to download wiki page: {e}", DateTimeOffset.Now);
                }
        }
    }
}