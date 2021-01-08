using System;
using System.Threading.Tasks;
using Bus.Abstractions;
using Bus.Events;
using Microsoft.Extensions.Logging;
using Posts.API.Repositories;

namespace Posts.API.BusEventHandlers
{
    public class WebPostDownloadedEventHandler : IIntegrationEventHandler<WebPostDownloadedEvent>
    {
        private readonly ILogger<WebPostDownloadedEventHandler> _logger;
        private readonly IPostsRepository _postsRepository;

        public WebPostDownloadedEventHandler(ILogger<WebPostDownloadedEventHandler> logger,
            IPostsRepository postsRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _postsRepository = postsRepository;
        }

        public async Task Handle(WebPostDownloadedEvent postEvent)
        {
            await Task.Run(() => _postsRepository.Insert(new PostDto
            {
                Body = postEvent.Post.Body,
                Subject = postEvent.Post.Subject,
                Url = postEvent.Post.Url
            }));
        }
    }
}