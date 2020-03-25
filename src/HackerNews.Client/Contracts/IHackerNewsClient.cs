using System.Threading;
using System.Threading.Tasks;
using Refit;
using System.Collections.Generic;
using HackerNews.Client.Models;

namespace HackerNews.Client.Contracts
{
    internal interface IHackerNewsClient
    {
        [Get("/topstories.json")]
        Task<ApiResponse<IEnumerable<long>>> GetTopStories(CancellationToken cancellationToken);

         [Get("/item/{id}")]
         Task<ApiResponse<Response>> GetStory(string id, CancellationToken cancellationToken);
    }
}