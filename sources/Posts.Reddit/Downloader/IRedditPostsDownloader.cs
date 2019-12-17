using System.Threading.Tasks;
using Posts.Reddit.Classes;

namespace Posts.Reddit.Downloader
{
    internal interface IRedditPostsDownloader
    {
        Task<RedditPost> GetRandomPostAsync();
    }
}