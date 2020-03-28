using System;
using HackerNews.Client.Models;

namespace HackerNews.Client.Builders
{
    internal class StoryBuilder
    {
        private int _orderNumber = 0;
        private Response _response;

        public StoryBuilder WithOrderNumber(int orderNumber)
        {
            _orderNumber = orderNumber;
            return this;
        }
        public StoryBuilder For(Response response)
        {
            _response = response;
            return this;
        }

        public Action Build() => 
            new Action(() => 
            {
                PrintTitle().Invoke();
                PrintUrl().Invoke();
                PrintPoints().Invoke();
            });

        private Action PrintTitle() =>
            new Action(() =>
            {
                Console.WriteLine();
                new TextBuilder($"{_orderNumber}. ")
                    .WithForegroundColor(ConsoleColor.White)
                    .DoesntEndWithNewLine()
                    .WithLeftPadding(2 - $"{_orderNumber}".Length)
                    .Build()
                    .Invoke();
                new TextBuilder(_response.Title)
                    .WithForegroundColor(ConsoleColor.White)
                    .DoesntEndWithNewLine()
                    .Build()
                    .Invoke();
            });

        private Action PrintUrl() =>
            new Action(() =>
            {
                new TextBuilder($" ({_response.Url})")
                    .WithForegroundColor(ConsoleColor.Blue)
                    .EndsWithNewLine()
                    .Build()
                    .Invoke();
            });

        private Action PrintPoints() =>
            new Action(() =>
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                int totalWidth = 2 - $"{_orderNumber}".Length;
                var value = $"{_orderNumber}. ".Length + totalWidth;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                var v = $"{_response.Score} points".PadLeft(value);
                Console.Write(v);
                Console.WriteLine();
            });
    }
}