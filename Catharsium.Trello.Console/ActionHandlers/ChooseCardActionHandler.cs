using Catharsium.Trello.Console.ActionHandlers.Interfaces;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class ChooseCardActionHandler : IChooseCardActionHandler
    {
        private readonly IConsole console;


        public ChooseCardActionHandler(IConsole console)
        {
            this.console = console;
        }


        public Card Run(IEnumerable<Card> cards)
        {
            var cardsArray = cards.ToArray();
            for (var i = 1; i <= cardsArray.Length; i++) {
                this.console.WriteLine($"[{i}] {cardsArray[i - 1]}");
            }

            var selectedIndex = this.console.AskForInt("Choose a card:");
            return selectedIndex != null && selectedIndex > 0 && selectedIndex <= cardsArray.Length
                ? cardsArray[selectedIndex.Value - 1]
                : null;
        }
    }
}