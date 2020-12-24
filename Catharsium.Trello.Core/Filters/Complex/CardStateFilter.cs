using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Enums;
using Catharsium.Trello.Models.Interfaces.Core.Filters.Cards;

namespace Catharsium.Trello.Core.Filters.Complex
{
    public class CardStateFilter : ICardStateFilter
    {
        private readonly CardState cardState;


        public CardStateFilter(CardState cardState)
        {
            this.cardState = cardState;
        }


        public bool Includes(Card item)
        {
            return this.cardState switch {
                CardState.Unplanned => !item.Due.HasValue,
                CardState.Planned => item.Due.HasValue,
                CardState.Open => (!item.DueComplete || !item.Due.HasValue),
                CardState.Completed => item.DueComplete,
                _ => false
            };
        }
    }
}