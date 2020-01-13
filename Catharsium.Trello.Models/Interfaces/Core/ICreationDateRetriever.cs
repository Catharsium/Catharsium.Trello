using System;

namespace Catharsium.Trello.Models.Interfaces.Core
{
    public interface ICreationDateRetriever
    {
        DateTime? FindCreationDate(string id);
        DateTime FindCreationDate(double secondsSinceEpoch);
    }
}