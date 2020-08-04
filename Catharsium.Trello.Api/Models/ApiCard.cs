using System;
using System.Collections.Generic;

namespace Catharsium.Trello.Api.Client.Models
{
    public class ApiCard
    {
        public string Id { get; set; }
        public object CheckItemStates { get; set; }
        public bool Closed { get; set; }
        public DateTime DateLastActivity { get; set; }
        public string Desc { get; set; }
        public object DescData { get; set; }
        public int? DueReminder { get; set; }
        public string IdBoard { get; set; }
        public string IdList { get; set; }
        public List<object> IdMembersVoted { get; set; }
        public int IdShort { get; set; }
        public object IdAttachmentCover { get; set; }
        public List<string> IdLabels { get; set; }
        public bool ManualCoverAttachment { get; set; }
        public string Name { get; set; }
        public decimal Pos { get; set; }
        public string ShortLink { get; set; }
        public bool IsTemplate { get; set; }
        public ApiBadges ApiBadges { get; set; }
        public bool DueComplete { get; set; }
        public DateTime? Due { get; set; }
        public List<string> IdChecklists { get; set; }
        public List<object> IdMembers { get; set; }
        public List<ApiLabel> Labels { get; set; }
        public string ShortUrl { get; set; }
        public bool Subscribed { get; set; }
        public string Url { get; set; }
        public ApiCover ApiCover { get; set; }
    }
}