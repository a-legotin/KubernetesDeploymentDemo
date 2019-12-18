using Common.Models;

namespace Posts.API
{
    public class PostDto : WebPost
    {
        public long Id { get; set; }
    }
}