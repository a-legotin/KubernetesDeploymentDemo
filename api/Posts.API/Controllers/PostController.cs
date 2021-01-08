using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Posts.API.Repositories;

namespace Posts.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostsRepository _postsRepository;

        public PostController(ILogger<PostController> logger,
            IPostsRepository postsRepository)
        {
            _logger = logger;
            _postsRepository = postsRepository;
        }

        [HttpGet]
        public IEnumerable<PostDto> Get() => _postsRepository.GetAll();
    }
}