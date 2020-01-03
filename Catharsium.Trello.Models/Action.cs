using System;
using System.Collections.Generic;

namespace Catharsium.Trello.Models
{
    public class Action
    {
        public string Id { get; set; }
        public string IdMemberCreator { get; set; }
        public ActionData Data { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        //public Limit[] Limits { get; set; }
        public MemberCreator MemberCreator { get; set; }
    }
}