using System.Linq;
using System.Threading.Tasks;
using Http;
using Posts.Reddit.Classes;
using Posts.Reddit.RedditResponse;

namespace Posts.Reddit.Downloader
{
    internal class RedditPostsDownloader : IRedditPostsDownloader
    {
        private readonly IHttpClient _httpClient;

        public RedditPostsDownloader(IHttpClient httpClient) => _httpClient = httpClient;

        public async Task<RedditPost> GetRandomPostAsync()
        {
            var postJson = await _httpClient.GetStringAsync("http://www.reddit.com/r/random.json");
            var post = RedditPostResponse.FromJson(postJson);
            var firstPost = post.Data.Children.FirstOrDefault()?.Data;
            return new RedditPost
            {
                Body = firstPost.SelftextHtml,
                Subject = firstPost.Title,
                Url = firstPost.Url
            };
        }
    }
}