using System;
using HackerNews.Client.Builders;
using HackerNews.Client.Models;

namespace HackerNews.Client.Extensions
{
    internal static class ResponseExtensions
    {
        internal static Action ToAction(this Response response, int orderNumber)
        {
            return new Action(() =>
            {
                Console.WriteLine();
                string orderNumberText = $"{orderNumber}.";
                FormatOrderNumber(orderNumberText)
                    .Invoke();
                FormatTitle(response.Title, orderNumberText)
                    .Invoke();
                FormatUrl(response.Url, orderNumber, orderNumberText)
                    .Invoke();
                FormatScore(response.Score, orderNumber, orderNumberText)
                    .Invoke();
                FormatAuthor(response.By)
                    .Invoke();
                Console.WriteLine();
            });
        }

        private static Action FormatOrderNumber(string orderNumberText) =>
             new TextBuilder(orderNumberText)
                .WithForegroundColor(ConsoleColor.White)
                .DoesntEndWithNewLine()
                .WithRightPadding(1)
                .Build();

        private static Action FormatTitle(string title, string orderNumberText) => 
            new TextBuilder(title)
                .WithForegroundColor(ConsoleColor.White)
                .EndsWithNewLine()
                .WithLeftPadding(3 - orderNumberText.Length)
                .Build();

         private static Action FormatUrl(Uri url, int orderNumber, string orderNumberText)
         {
            string value = $"{url}";
            return new TextBuilder(string.IsNullOrEmpty(value) ? "Not available" : value)
                .WithForegroundColor(ConsoleColor.DarkYellow)
                .EndsWithNewLine()
                .WithLeftPadding((3 - orderNumberText.Length) + 2 + orderNumber.ToString().Length)
                .Build();
         }

        private static Action FormatScore(long score, int orderNumber, string orderNumberText) => 
            new TextBuilder($"{score} points")
                .WithForegroundColor(ConsoleColor.Gray)
                .WithLeftPadding((3 - orderNumberText.Length) + 2 + orderNumber.ToString().Length)
                .DoesntEndWithNewLine()
                .Build();

        private static Action FormatAuthor(string author) =>
            new TextBuilder($"by {author}")
                .WithForegroundColor(ConsoleColor.Gray)
                .WithLeftPadding(3)
                .DoesntEndWithNewLine()
                .Build();

    }
}