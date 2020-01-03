using System;
using System.Collections.Generic;

namespace Catharsium.Trello.Models
{
    public class Card
    {
        public string Id { get; set; }
        //address
        //checkItemStates
        public bool Closed { get; set; }
        //coordinates
        //creationMethod
        public DateTime DateLastActivity { get; set; }
        //desc
        //descData
        public int? DueReminder { get; set; }
        public string IdBoard { get; set; }
        public List<string> IdLabels { get; set; }
        public string IdList { get; set; }
        public List<string> IdMembersVoted { get; set; }
        public int IdShort { get; set; }
        public string IdAttachmentCover { get; set; }
        //limits
        public string LocationName { get; set; }
        public bool ManualCoverAttachment { get; set; }
        public string Name { get; set; }
        public decimal Pos { get; set; }
        public string ShortLink { get; set; }
        public bool IsTemplate { get; set; }
        public Badges Badges { get; set; }
        public bool DueComplete { get; set; }
        //due
        public string Email { get; set; }
        public List<string> IdChecklists { get; set; }
        public List<string> IdMembers { get; set; }
        public List<Label> Labels { get; set; }
        public string ShortUrl { get; set; }
        public bool Subscribed { get; set; }
        public string Url { get; set; }
        //cover
        //attachments
        //pluginData
        //customFieldItems
    }
}