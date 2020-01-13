namespace Catharsium.Trello.Models.Interfaces.Core
{
    public interface ICardFilter
    {
        bool Includes(Card card);
    }
}