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
                Console.WriteLine();
                string orderNumberText = $"{_orderNumber}. ";
                new TextBuilder(orderNumberText)
                    .WithForegroundColor(ConsoleColor.White)
                    .DoesntEndWithNewLine()
                    .WithLeftPadding(orderNumberText.Length + 2 - $"{_orderNumber}".Length)
                    .Build()
                    .Invoke();
                new TextBuilder(_response.Title)
                    .WithForegroundColor(ConsoleColor.White)
                    .DoesntEndWithNewLine()
                    .Build()
                    .Invoke();
                new TextBuilder($" ({_response.Url})")
                    .WithForegroundColor(ConsoleColor.Blue)
                    .EndsWithNewLine()
                    .Build()
                    .Invoke();
                string pointsText = $"{_response.Score} points";
                new TextBuilder(pointsText)
                    .WithForegroundColor(ConsoleColor.Cyan)
                    .WithLeftPadding(pointsText.Length + orderNumberText.Length + (2 - $"{_orderNumber}".Length))
                    .EndsWithNewLine()
                    .Build()
                    .Invoke();
            });
    }
}