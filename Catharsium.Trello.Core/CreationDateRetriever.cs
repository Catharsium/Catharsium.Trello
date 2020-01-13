using Catharsium.Trello.Models.Interfaces.Core;
using System;

namespace Catharsium.Trello.Core
{
    public class CreationDateRetriever : ICreationDateRetriever
    {
        public DateTime? FindCreationDate(string id)
        {
            return this.FindCreationDate(Convert.ToInt32(id.Substring(0, 8), 16));
        }


        public DateTime FindCreationDate(double secondsSinceEpoch)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            result = result.AddSeconds(secondsSinceEpoch);
            return result;
        }
    }
}