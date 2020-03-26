using System;
using System.Collections.Generic;

namespace HackerNews.Client.Extensions
{
    internal static class EnumerableExtensions
    {
        public static void RunAll(this IEnumerable<Action> actions)
        {
            foreach(var action in actions)
            {
                action.Invoke();
            }
        }
    }
}