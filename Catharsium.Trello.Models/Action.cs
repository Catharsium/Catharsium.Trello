using System;

namespace Catharsium.Trello.Models
{
    public class Action
    {
        public string Id { get; set; }
        public string IdMemberCreator { get; set; }
        //data
        public string Type { get; set; }
        public DateTime Date { get; set; }
        //limits
        //memberCreator
    }
}