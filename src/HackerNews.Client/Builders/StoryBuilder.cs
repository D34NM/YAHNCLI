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
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{_orderNumber}. ");
                int totalWidth = 2 - $"{_orderNumber}".Length;
                string value1 = $"{_response.Title}".PadLeft(totalWidth);
                Console.Write(value1);
            });

        private Action PrintUrl() =>
            new Action(() =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($" ({_response.Url})");
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