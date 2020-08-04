namespace Catharsium.Trello.Models.Interfaces.Data
{
    public interface ITrelloRepositoryFactory
    {
        ITrelloRepository Create(string folder);
    }
}