using System;
using Catharsium.Trello.Models;
using System.Threading.Tasks;

namespace Catharsium.Trello.Api.Client.Interfaces
{
    public interface ICardsClient
    {
        Task<Card> CreateNew(string name, string boardId, string listId, string position = null, string[] labels = null, DateTime? due = null, bool isDone = false);
    }
}