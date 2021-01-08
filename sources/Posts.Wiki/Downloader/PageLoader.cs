using System;
using System.Linq;
using System.Threading.Tasks;
using Http;
using Posts.Wiki.Classes;
using Posts.Wiki.WikiResponse;

namespace Posts.Wiki.Downloader
{
    internal class WikiPageDownloader : IWikiPageDownloader
    {
        private readonly IHttpClient _httpClient;

        public WikiPageDownloader(IHttpClient httpClient) => _httpClient = httpClient;

        public async Task<WikiPage> GetRandomWikiPage()
        {
            var pagePreviewJson =
                await _httpClient.GetStringAsync(
                    "https://en.wikipedia.org/w/api.php?action=query&format=json&list=random&rnlimit=1");
            var randomPageTitle = RandomWikiPostResponse.FromJson(pagePreviewJson).Query.Random.FirstOrDefault().Title;

            var pageInfoJson = await _httpClient.GetStringAsync(
                $"https://en.wikipedia.org/w/api.php?action=query&titles={Uri.EscapeDataString(randomPageTitle)}&prop=info&inprop=url&format=json");
            var pageInfo = WikiPostInfoResponse.FromJson(pageInfoJson).Query.Pages.FirstOrDefault().Value;

            var pageJson = await _httpClient.GetStringAsync(
                $"https://en.wikipedia.org/w/api.php?action=parse&pageid={pageInfo.Pageid}&format=json");
            var wikiPage = WikiPostResponse.FromJson(pageJson);
            return new WikiPage
            {
                Body = wikiPage.Parse.Text.Content,
                Subject = wikiPage.Parse.Title,
                Url = pageInfo.Fullurl
            };
        }
    }
}