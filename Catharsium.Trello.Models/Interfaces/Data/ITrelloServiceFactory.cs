namespace Catharsium.Trello.Models.Interfaces.Data
{
    public interface ITrelloServiceFactory
    {
        ITrelloService Create(string folder);
    }
}