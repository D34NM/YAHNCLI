using System.Collections.Generic;
using System;

namespace HackerNews.Client.Builders
{
    public class TextBuilder
    {
        private readonly Dictionary<bool, Action<string>> _consoleActionMapping = new Dictionary<bool, Action<string>>
        {
            { true, new Action<string>((stringToPrintOut) => Console.WriteLine(stringToPrintOut)) },
            { false, new Action<string>((stringToPrintOut) => Console.Write(stringToPrintOut)) }
        };

        private ConsoleColor _foregroundColor;
        private string _textToPrint;
        private int _paddingLeft;
        private int _paddingRight;
        private bool _endsWithNewLine;

        public TextBuilder(string textToPrint)
        {
            if (textToPrint is null)
            {
                throw new ArgumentNullException(nameof(textToPrint));
            }

            _textToPrint = textToPrint;
        }

        public TextBuilder WithForegroundColor(ConsoleColor foregroundColor)
        {
            _foregroundColor = foregroundColor;
            return this;
        }

        public TextBuilder WithLeftPadding(int paddingLeft)
        {
            _paddingLeft = paddingLeft;
            return this;
        }

        public TextBuilder WithRightPadding(int paddingRight)
        {
            _paddingRight = paddingRight;
            return this;
        }

        public TextBuilder DoesntEndWithNewLine()
        {
            _endsWithNewLine = false;
            return this;
        }

        public TextBuilder EndsWithNewLine()
        {
            _endsWithNewLine = true;
            return this;
        }

        public Action Build()
        {
            return new Action(() => 
            {
                Console.ForegroundColor = _foregroundColor;
                var paddedLeftText = _textToPrint.PadLeft(_paddingLeft, ' ');
                var paddedLeftAndRightText = _textToPrint.PadRight(_paddingRight, ' ');
                var action = _consoleActionMapping[_endsWithNewLine];
                action.Invoke(paddedLeftAndRightText);
            });
        }
    }
}