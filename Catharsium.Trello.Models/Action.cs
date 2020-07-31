using System;

namespace Catharsium.Trello.Models
{
    public class Action
    {
        public string Id { get; set; }
        public string IdMemberCreator { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public object Limits { get; set; }
        public Member MemberCreator { get; set; }
    }
}