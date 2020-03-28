using System.Threading;
using System.Threading.Tasks;
using HackerNews.Client.Contracts;
using System.Linq;
using HackerNews.Client.Models;
using HackerNews.Client.Extensions;

namespace HackerNews.Client
{
    internal class Runner
    {
        private readonly IHackerNewsClient _client;

        public Runner(IHackerNewsClient client)
        {
            _client = client;
        }

        public async Task Start(string[] args, CancellationToken cancellationToken)
        {
            var storyIds = await _client.GetTopStories(cancellationToken);
                
            var tasks = storyIds.Content
                .Take(30)
                .Select(id => _client.GetStory(new StoryId { Value = id }, cancellationToken))
                .ToArray();
            
            var stories = await Task.WhenAll(tasks);

            stories
                .Select((story, index) => 
                    story.Content.ToAction(index + 1))
                .RunAll();
        }
    }
}