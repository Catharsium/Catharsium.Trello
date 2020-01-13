﻿using Catharsium.Trello.Console.Interfaces;
using Catharsium.Trello.Models;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Trello.Console.ActionHandlers
{
    public class ChooseListActionHandler : IChooseListActionHandler
    {
        private readonly IConsole console;


        public ChooseListActionHandler(IConsole console)
        {
            this.console = console;
        }


        public List Run(IEnumerable<List> lists)
        {
            var listsArray = lists.ToArray();
            for (var i = 1; i <= listsArray.Length; i++) {
                this.console.WriteLine($"[{i}] {listsArray[i - 1]}");
            }

            var selectedIndex = this.console.AskForInt("Choose a list:");
            return selectedIndex != null && selectedIndex > 0 && selectedIndex <= listsArray.Length
                ? listsArray[selectedIndex.Value - 1]
                : null;
        }
    }
}