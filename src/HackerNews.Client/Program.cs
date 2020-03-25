using System.Threading;
using System;
using System.Threading.Tasks;
using HackerNews.Client.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;

namespace HackerNews.Client
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                                .Build();

            using (host)
            {
                var runner = host.Services.GetService<Runner>();
                await runner.Start(args, CancellationToken.None);
            }
        }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(loggingBuilder => 
            {
                loggingBuilder.ClearProviders();
            })
            .ConfigureServices((_, services) =>
            {
                services.AddRefitClient<IHackerNewsClient>()
                        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/"));

                services.AddSingleton<Runner>();
            });
    }
}
