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
                string orderNumberText = $"{_orderNumber}.";
                new TextBuilder(orderNumberText)
                    .WithForegroundColor(ConsoleColor.White)
                    .DoesntEndWithNewLine()
                    .WithLeftPadding(2 - orderNumberText.Length)
                    .WithRightPadding(1)
                    .Build()
                    .Invoke();
                new TextBuilder(_response.Title)
                    .WithForegroundColor(ConsoleColor.White)
                    .DoesntEndWithNewLine()
                    .Build()
                    .Invoke();
                string urlText = _response.Url.ToString();
                new TextBuilder(urlText)
                    .WithForegroundColor(ConsoleColor.Blue)
                    .EndsWithNewLine()
                    .WithLeftPadding(1)
                    .Build()
                    .Invoke();
                string pointsText = $"{_response.Score} points";
                new TextBuilder(pointsText)
                    .WithForegroundColor(ConsoleColor.Cyan)
                    .WithLeftPadding(orderNumberText.Length + (2 - _orderNumber.ToString().Length))
                    .EndsWithNewLine()
                    .Build()
                    .Invoke();
            });
    }
}