using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Trello.Core.Filters.Extensions
{
    public static class FilterExtensions
    {
        public static IEnumerable<Card> Include<T>(this IEnumerable<Card> cards, T filter) where T : ICardFilter
        {
            return cards.Where(filter.Includes);
        }


        public static IEnumerable<Card> Exclude<T>(this IEnumerable<Card> cards, T filter) where T : ICardFilter
        {
            return cards.Where(t => !filter.Includes(t));
        }
    }
}