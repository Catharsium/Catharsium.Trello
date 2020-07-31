using System;

namespace Catharsium.Trello.Api.Client.Models
{
    public class ApiAction
    {
        public string Id { get; set; }
        public string IdMemberCreator { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public object Limits { get; set; }
        public ApiMember MemberCreator { get; set; }
    }
}