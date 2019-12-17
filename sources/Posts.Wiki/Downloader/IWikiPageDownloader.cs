using System.Threading.Tasks;
using Posts.Wiki.Classes;

namespace Posts.Wiki.Downloader
{
    internal interface IWikiPageDownloader
    {
        Task<WikiPage> GetRandomWikiPage();
    }
}