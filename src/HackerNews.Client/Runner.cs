using System.Threading;
using System;
using System.Threading.Tasks;
using HackerNews.Client.Contracts;
using System.Linq;
using HackerNews.Client.Models;

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
                .Take(15)
                .Select(id => _client.GetStory(new StoryId { Value = id }, cancellationToken))
                .ToArray();
            
            var stories = await Task.WhenAll(tasks);

            for (var i = 0; i < stories.Length; i++)
            {
                var task = tasks[i];
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{i + 1}. ");
                int totalWidth = 2 - $"{i + 1}".Length;
                string value1 = $"{task.Result.Content.Title}".PadLeft(totalWidth);
                Console.Write(value1);

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($" ({task.Result.Content.Url})");
                
                var value = $"{i + 1}. ".Length + totalWidth;
                Console.Write("└".PadRight(value));
                
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                var v = $"Score: {task.Result.Content.Score}";
                Console.Write(v);
                Console.WriteLine();
            }
        }
    }
}