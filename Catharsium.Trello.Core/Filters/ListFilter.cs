using Catharsium.Trello.Models;
using Catharsium.Trello.Models.Interfaces.Core.Filters.Cards;
using System.Linq;

namespace Catharsium.Trello.Core.Filters
{
    public class ListFilter : IListFilter
    {
        private readonly string[] listIds;


        public ListFilter(string[] listIds)
        {
            this.listIds = listIds;
        }


        public bool Includes(Card item)
        {
            return this.listIds.Any(id => item.IdList == id);
        }
    }
}